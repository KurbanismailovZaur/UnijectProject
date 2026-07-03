using System;
using System.Collections.Generic;
using System.Reflection;
using Uniject;
using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class Test : MonoBehaviour
{
    private const string LogPrefix = "[Uniject Runtime Test]";

    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy[] _enemiesPrefabs;

    private readonly List<GameObject> _createdGameObjects = new();
    private int _passedCount;
    private int _failedCount;

    private void Start()
    {
        RunContainerTest();
    }

    private void RunContainerTest()
    {
        ResetProbeState();
        Debug.Log($"{LogPrefix} START", this);

        Container container = null;
        RuntimeItemPool itemPool = null;
        Enemy.Pool enemyPool = null;
        var subcontainerInstallCount = 0;
        var queuedTarget = new InjectionTarget();
        var settings = new RuntimeSettings("root-settings");

        try
        {
            RunCase("Configuration and Build lifecycle", () =>
            {
                container = new Container
                {
                    ParentTransformForGameObjects = transform
                };

                container.BindInstance(settings);
                container.Bind<IRuntimeSettings>().FromInstance(settings).AsCached();
                container.Bind<IRuntimeService>().To<RuntimeService>().AsCached();
                container.Bind<TransientConsumer>().AsTransient();
                container.Bind<NonLazyProbe>().AsTransient().NonLazy();
                container.Bind<LifecycleProbe>().AsEntryPoint();

                container.BindFactory<FactoryProduct, FactoryProductFactory>()
                    .FromConstructor()
                    .AsCached();

                container.BindPool<RuntimePooledItem, RuntimeItemPool>()
                    .WithInitialSize(2)
                    .WithMaxSize(4)
                    .ExpandByDoubling()
                    .FromConstructor()
                    .AsCached();

                container.Bind<SubcontainerProduct>()
                    .FromSubcontainerResolve()
                    .ByMethod(subcontainer =>
                    {
                        subcontainerInstallCount++;
                        subcontainer.Bind<SubcontainerProduct>().AsTransient();
                    })
                    .AsCached();

                container.Bind(typeof(DynamicService)).AsCached();
                container.Bind<string>().FromInstance("injected message").AsCached();
                container.Bind<float>().FromInstance(3.14159f).AsCached();
                container.BindFactory<Enemy, Enemy, EnemyPrefabFactory>()
                    .FromComponentInNewPrefab()
                    .AsCached();

                if (_characterPrefab != null)
                {
                    container.Bind<ICharacter>()
                        .To<Character>()
                        .FromComponentInNewPrefab(_characterPrefab)
                        .WithGameObjectName("Runtime Character")
                        .AsCached();
                }

                if (_enemyPrefab != null)
                {
                    container.BindPool<Enemy, Enemy.Pool>()
                        .WithInitialSize(2)
                        .WithMaxSize(4)
                        .ExpandByDoubling()
                        .FromComponentInNewPrefab(_enemyPrefab)
                        .AsCached();
                }

                container.AddToInjectionQueue(queuedTarget);

                Require(!container.IsBuilded, "A new container must not be marked as built.");
                Build(container);

                Require(container.IsBuilded, "Build did not update IsBuilded.");
                Require(NonLazyProbe.InstancesCount == 1, "NonLazy binding was not created exactly once.");
                Require(queuedTarget.Settings == settings, "Queued method injection did not receive the bound instance.");
                Require(queuedTarget.Service != null, "Queued method injection did not receive the service.");
                Require(LifecycleProbe.RunsCount == 1, "Entry point was not run exactly once.");

                Build(container);
                Require(NonLazyProbe.InstancesCount == 1, "The second Build recreated a NonLazy binding.");
                Require(queuedTarget.CallsCount == 1, "The second Build repeated queued injection.");
                Require(LifecycleProbe.RunsCount == 1, "The second Build reran the entry point.");
            });

            RunCase("Resolve, cached/transient scopes and dynamic API", () =>
            {
                var currentContainer = RequireContainer(container);
                var firstService = currentContainer.Resolve<IRuntimeService>();
                var secondService = currentContainer.Resolve<IRuntimeService>();
                var firstConsumer = currentContainer.Resolve<TransientConsumer>();
                var secondConsumer = currentContainer.Resolve<TransientConsumer>();
                var firstDynamic = (DynamicService)currentContainer.Resolve(typeof(DynamicService));
                var secondDynamic = currentContainer.Resolve<DynamicService>();

                Require(ReferenceEquals(currentContainer, currentContainer.Resolve<Container>()),
                    "Container self-binding returned another instance.");
                Require(ReferenceEquals(currentContainer, currentContainer.Resolve<IObjectBuilder>()),
                    "IObjectBuilder self-binding returned another instance.");
                Require(ReferenceEquals(settings, currentContainer.Resolve<RuntimeSettings>()),
                    "BindInstance did not preserve the original instance.");
                Require(ReferenceEquals(settings, currentContainer.Resolve<IRuntimeSettings>()),
                    "Interface binding did not preserve the original instance.");
                Require(ReferenceEquals(firstService, secondService), "Cached service returned different instances.");
                Require(!ReferenceEquals(firstConsumer, secondConsumer), "Transient binding returned the same instance.");
                Require(ReferenceEquals(firstConsumer.Service, firstService),
                    "Transient constructor dependency was not resolved from the cache.");
                Require(ReferenceEquals(firstDynamic, secondDynamic),
                    "Bind(Type) / Resolve(Type) did not respect cached scope.");
            });

            RunCase("Instantiate and direct/collection method injection", () =>
            {
                var currentContainer = RequireContainer(container);
                var constructed = currentContainer.Instantiate<ConstructorTarget>();
                var firstTarget = new InjectionTarget();
                var secondTarget = new InjectionTarget();

                currentContainer.Inject(new object[] { firstTarget, secondTarget });

                Require(constructed.Service != null, "Instantiate did not perform constructor injection.");
                Require(constructed.UsedInjectConstructor, "Instantiate ignored the [Inject] constructor.");
                Require(ReferenceEquals(firstTarget.Settings, settings), "Collection injection failed for item #1.");
                Require(ReferenceEquals(secondTarget.Settings, settings), "Collection injection failed for item #2.");
                Require(firstTarget.CallsCount == 1 && secondTarget.CallsCount == 1,
                    "Collection injection called an [Inject] method an unexpected number of times.");
            });

            RunCase("Factory API", () =>
            {
                var currentContainer = RequireContainer(container);
                var firstFactory = currentContainer.Resolve<FactoryProductFactory>();
                var secondFactory = currentContainer.Resolve<FactoryProductFactory>();
                var firstProduct = firstFactory.Create();
                var secondProduct = firstFactory.Create();

                Require(ReferenceEquals(firstFactory, secondFactory), "Cached factory returned different instances.");
                Require(!ReferenceEquals(firstProduct, secondProduct), "Factory returned the same transient product.");
                Require(firstProduct.Service != null && secondProduct.Service != null,
                    "Factory products did not receive constructor dependencies.");
                Require(ReferenceEquals(firstProduct.Service, secondProduct.Service),
                    "Factory products did not receive the cached service.");
            });

            RunCase("Pool API: prewarm, growth, reuse, reset and max size", () =>
            {
                var currentContainer = RequireContainer(container);
                itemPool = currentContainer.Resolve<RuntimeItemPool>();
                var secondPoolResolve = currentContainer.Resolve<RuntimeItemPool>();

                Require(ReferenceEquals(itemPool, secondPoolResolve), "Cached pool returned different instances.");
                Require(itemPool.InstanceCount == 2, "Pool was not prewarmed to InitialSize.");

                var first = itemPool.Spawn();
                var second = itemPool.Spawn();
                var third = itemPool.Spawn();

                Require(itemPool.InstanceCount == 4, "ExpandByDoubling did not grow 2 -> 4.");
                Require(!ReferenceEquals(first, second) && !ReferenceEquals(second, third),
                    "Pool returned the same object while it was already spawned.");
                Require(first.Service != null, "A pooled item did not receive constructor dependencies.");

                first.Value = 42;
                itemPool.Despawn(first);
                var reused = itemPool.Spawn();
                Require(ReferenceEquals(first, reused), "Pool did not reuse the last despawned item.");
                Require(reused.Value == 0, "Pool.Reset did not restore item state.");

                var fourth = itemPool.Spawn();
                ExpectException<InvalidOperationException>(() => itemPool.Spawn());

                itemPool.Despawn(second);
                itemPool.Despawn(third);
                itemPool.Despawn(reused);
                itemPool.Despawn(fourth);
            });

            RunCase("Parent container and local override", () =>
            {
                var currentContainer = RequireContainer(container);
                using var child = new Container(currentContainer);
                using var overriddenChild = new Container(currentContainer);
                var childSettings = new RuntimeSettings("child-settings");

                overriddenChild.Bind<IRuntimeSettings>().FromInstance(childSettings).AsCached();

                Require(ReferenceEquals(child.Resolve<IRuntimeSettings>(), settings),
                    "Child container did not fall back to the parent binding.");
                Require(ReferenceEquals(overriddenChild.Resolve<IRuntimeSettings>(), childSettings),
                    "Child binding did not override the parent binding.");
            });

            RunCase("Subcontainer resolve and caching", () =>
            {
                var currentContainer = RequireContainer(container);
                var first = currentContainer.Resolve<SubcontainerProduct>();
                var second = currentContainer.Resolve<SubcontainerProduct>();

                Require(subcontainerInstallCount == 1, "Cached subcontainer was installed more than once.");
                Require(!ReferenceEquals(first, second),
                    "Transient binding inside the cached subcontainer returned the same instance.");
                Require(ReferenceEquals(first.Settings, settings) && ReferenceEquals(second.Settings, settings),
                    "Subcontainer did not resolve dependencies from its parent.");
            });

            RunCase("Unity AddComponent with injection", () =>
            {
                var currentContainer = RequireContainer(container);
                var host = Track(new GameObject("Runtime Injected Component Host"));
                var component = currentContainer.AddComponent<Enemy2>(host);
                var message = GetPrivateField<string>(component, "_message");
                var pi = GetPrivateField<float>(component, "_pi");

                Require(message == "injected message", "AddComponent did not inject the string binding.");
                Require(Mathf.Approximately(pi, 3.14159f), "AddComponent did not inject the float binding.");
            });

            RunCase("Unity component binding from prefab", () =>
            {
                Require(_characterPrefab != null, "Character prefab is not assigned in the Test component.");

                var currentContainer = RequireContainer(container);
                var character = currentContainer.Resolve<ICharacter>() as Character;

                Require(character != null, "ICharacter did not resolve to Character.");
                Track(character.gameObject);
                Require(character != _characterPrefab, "Container returned the prefab itself instead of a clone.");
                Require(character.gameObject.name == "Runtime Character", "WithGameObjectName was not applied.");
                Require(character.transform.parent == transform,
                    "ParentTransformForGameObjects was not applied to the resolved component.");

                character.Move();
            });

            RunCase("Parameterized prefab factory", () =>
            {
                Require(_enemiesPrefabs != null && _enemiesPrefabs.Length > 0,
                    "Enemy prefabs array is empty in the Test component.");

                var currentContainer = RequireContainer(container);
                var factory = currentContainer.Resolve<EnemyPrefabFactory>();

                for (var i = 0; i < _enemiesPrefabs.Length; i++)
                {
                    var prefab = _enemiesPrefabs[i];
                    Require(prefab != null, $"Enemy prefab at index {i} is null.");

                    var clone = factory.Create(prefab);
                    Track(clone.gameObject);
                    Require(clone != prefab, $"Factory returned prefab itself at index {i}.");
                }
            });

            RunCase("Unity prefab pool", () =>
            {
                Require(_enemyPrefab != null, "Enemy prefab is not assigned in the Test component.");

                var currentContainer = RequireContainer(container);
                enemyPool = currentContainer.Resolve<Enemy.Pool>();
                Require(enemyPool.InstanceCount == 2, "Enemy pool was not prewarmed.");

                var enemy = enemyPool.Spawn();
                Require(enemy.gameObject.activeSelf, "Spawn did not activate the enemy GameObject.");

                enemy.Health = 1;
                enemyPool.Despawn(enemy);
                Require(!enemy.gameObject.activeSelf, "Despawn did not deactivate the enemy GameObject.");

                var reused = enemyPool.Spawn();
                Require(ReferenceEquals(enemy, reused), "Enemy pool did not reuse the despawned component.");
                Require(reused.Health == 100, "Enemy pool did not reset Health.");
                enemyPool.Despawn(reused);
            });

            RunCase("Dispose lifecycle", () =>
            {
                var currentContainer = RequireContainer(container);
                currentContainer.Dispose();
                Require(LifecycleProbe.DisposeCount == 1,
                    "Container.Dispose did not dispose the non-Component entry point exactly once.");
            });
        }
        finally
        {
            try
            {
                enemyPool?.Clear();
                itemPool?.Clear();
                container?.Dispose();
                DestroyCreatedGameObjects();
            }
            catch (Exception exception)
            {
                _failedCount++;
                Debug.LogError($"{LogPrefix} FAIL: Cleanup\n{exception}", this);
            }

            var summary = $"{LogPrefix} FINISH: passed={_passedCount}, failed={_failedCount}";
            if (_failedCount == 0)
                Debug.Log(summary, this);
            else
                Debug.LogError(summary, this);
        }
    }

    private void RunCase(string name, Action testCase)
    {
        try
        {
            testCase();
            _passedCount++;
            Debug.Log($"{LogPrefix} PASS: {name}", this);
        }
        catch (Exception exception)
        {
            _failedCount++;
            Debug.LogError($"{LogPrefix} FAIL: {name}\n{exception}", this);
        }
    }

    private GameObject Track(GameObject gameObject)
    {
        _createdGameObjects.Add(gameObject);
        return gameObject;
    }

    private void DestroyCreatedGameObjects()
    {
        foreach (var gameObject in _createdGameObjects)
        {
            if (gameObject != null)
                Destroy(gameObject);
        }

        _createdGameObjects.Clear();
    }

    private static Container RequireContainer(Container container)
    {
        return container ?? throw new InvalidOperationException("Container configuration failed.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
            throw new InvalidOperationException(message);
    }

    private static void ExpectException<TException>(Action action) where TException : Exception
    {
        try
        {
            action();
        }
        catch (TException)
        {
            return;
        }

        throw new InvalidOperationException($"Expected exception {typeof(TException).Name} was not thrown.");
    }

    private static T GetPrivateField<T>(object instance, string fieldName)
    {
        var field = instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (field == null)
            throw new MissingFieldException(instance.GetType().FullName, fieldName);

        return (T)field.GetValue(instance);
    }

    private static void Build(Container container)
    {
        var method = typeof(Container).GetMethod("Build", BindingFlags.Instance | BindingFlags.NonPublic);
        if (method == null)
            throw new MissingMethodException(typeof(Container).FullName, "Build");

        try
        {
            method.Invoke(container, null);
        }
        catch (TargetInvocationException exception) when (exception.InnerException != null)
        {
            throw new InvalidOperationException("Container.Build failed.", exception.InnerException);
        }
    }

    private static void ResetProbeState()
    {
        NonLazyProbe.InstancesCount = 0;
        LifecycleProbe.RunsCount = 0;
        LifecycleProbe.DisposeCount = 0;
    }

    private interface IRuntimeSettings
    {
        string Name { get; }
    }

    private sealed class RuntimeSettings : IRuntimeSettings
    {
        public string Name { get; }

        public RuntimeSettings(string name)
        {
            Name = name;
        }
    }

    private interface IRuntimeService
    {
        IRuntimeSettings Settings { get; }
    }

    private sealed class RuntimeService : IRuntimeService
    {
        public IRuntimeSettings Settings { get; }

        public RuntimeService(IRuntimeSettings settings)
        {
            Settings = settings;
        }
    }

    private sealed class TransientConsumer
    {
        public IRuntimeService Service { get; }

        public TransientConsumer(IRuntimeService service)
        {
            Service = service;
        }
    }

    private sealed class ConstructorTarget
    {
        public IRuntimeService Service { get; }
        public bool UsedInjectConstructor { get; }

        public ConstructorTarget()
        {
        }

        [Inject]
        public ConstructorTarget(IRuntimeService service)
        {
            Service = service;
            UsedInjectConstructor = true;
        }
    }

    private sealed class InjectionTarget
    {
        public IRuntimeSettings Settings { get; private set; }
        public IRuntimeService Service { get; private set; }
        public int CallsCount { get; private set; }

        [Inject]
        private void Construct(IRuntimeSettings settings, IRuntimeService service)
        {
            Settings = settings;
            Service = service;
            CallsCount++;
        }
    }

    private sealed class NonLazyProbe
    {
        public static int InstancesCount { get; set; }

        public NonLazyProbe()
        {
            InstancesCount++;
        }
    }

    private sealed class LifecycleProbe : IEntryPoint, IDisposable
    {
        public static int RunsCount { get; set; }
        public static int DisposeCount { get; set; }

        private readonly IRuntimeService _service;

        public LifecycleProbe(IRuntimeService service)
        {
            _service = service;
        }

        public void Run()
        {
            if (_service == null)
                throw new InvalidOperationException("Entry point dependency was not injected.");

            RunsCount++;
        }

        public void Dispose()
        {
            DisposeCount++;
        }
    }

    private sealed class FactoryProduct
    {
        public IRuntimeService Service { get; }

        public FactoryProduct(IRuntimeService service)
        {
            Service = service;
        }
    }

    private sealed class FactoryProductFactory : Factory<FactoryProduct>
    {
        public FactoryProductFactory()
        {
        }
    }

    private sealed class RuntimePooledItem
    {
        public IRuntimeService Service { get; }
        public int Value { get; set; }

        public RuntimePooledItem(IRuntimeService service)
        {
            Service = service;
        }
    }

    private sealed class RuntimeItemPool : Pool<RuntimePooledItem>
    {
        public RuntimeItemPool()
        {
        }

        protected override void Reset(RuntimePooledItem instance)
        {
            instance.Value = 0;
        }
    }

    private sealed class SubcontainerProduct
    {
        public IRuntimeSettings Settings { get; }

        public SubcontainerProduct(IRuntimeSettings settings)
        {
            Settings = settings;
        }
    }

    private sealed class DynamicService
    {
        public DynamicService()
        {
        }
    }

    private sealed class EnemyPrefabFactory : Factory<Enemy, Enemy>
    {
        public EnemyPrefabFactory()
        {
        }
    }
}

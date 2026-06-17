using System.Collections;
using System.Reflection;
using Uniject;
using Uniject.Factories;
using Uniject.Lifecycle;
using Uniject.Tests;
using Uniject.Tests.Fixtures;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;

    private static void ResolveNonLazyBindings(Container container)
    {
        var method = typeof(Container).GetMethod("ResolveNonLazyBindings", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(container, null);
    }

    private static void InjectQueuedInstances(Container container)
    {
        var method = typeof(Container).GetMethod("InjectQueuedInstances", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(container, null);
    }

    private static void CallEntryPoints(Container container)
    {
        var method = typeof(Container).GetMethod("CallEntryPoints", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(container, null);
    }

    private IEnumerator Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy().AsEntryPoint();
        
        var container = new Container();
        container.Bind<Enemy.Factory>().AsCached();

        var enemyFactory = container.Resolve<Enemy.Factory>();
        enemyFactory.Create().Initialize();
        enemyFactory.Create().Initialize();

        ResolveNonLazyBindings(container);
        InjectQueuedInstances(container);
        CallEntryPoints(container);

        yield return new WaitForSeconds(1);
    }
}

class Enemy : MonoBehaviour
{
    public class Factory : Factory<Enemy>
    {
        public Factory(IObjectBuilder objectBuilder) : base(objectBuilder) { }

        public override Enemy Create() => _objectBuilder.AddComponent<Enemy>(new GameObject("Enemy"));
    }

    public void Initialize()
    {
        Debug.Log("Enemy Initialized!");
    }
}
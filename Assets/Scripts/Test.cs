using System.Collections;
using System.Reflection;
using Uniject;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy2 _enemy2Prefab;

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

    private static void RunEntryPoints(Container container)
    {
        var method = typeof(Container).GetMethod("RunEntryPoints", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(container, null);
    }

    private static void Build(Container container)
    {
        var method = typeof(Container).GetMethod("Build", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(container, null);
    }

    private IEnumerator Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy().AsEntryPoint();
        // Container.BindFactory<TResult, TFactory>().To<TConcrete>().From*().AsScope();
        
        var container = new Container();

        container.BindFactory<Enemy, Enemy>().FromFactory<Enemy.CustomFactory2>().AsCached();

        container.Bind<Enemy>().FromComponentInNewPrefab(_enemyPrefab);
        container.Bind<Enemy1>().FromNewComponentOnNewGameObject();
        container.Bind<Enemy2>().FromComponentInNewPrefab(_enemy2Prefab);
        container.BindInstances("Hello!", 3.1415f);

        Build(container);

        var fact = container.Resolve<Factory<Enemy, Enemy>>();

        yield return new WaitForSeconds(2f);

        var enemy = fact.Create(_enemyPrefab);

        // var fact1 = container.Resolve<Factory<Enemy, Enemy>>();
        // var fact2 = container.Resolve<Factory<Enemy, Enemy>>();

        // Debug.Log($"Factory 1 {fact1.GetHashCode()}");
        // Debug.Log($"Factory 2 {fact2.GetHashCode()}");

        // fact1.Create(_enemyPrefab).Initialize();
        // fact1.Create(_enemyPrefab).Initialize();
        // fact2.Create(_enemyPrefab).Initialize();
        // fact2.Create(_enemyPrefab).Initialize();

        yield return new WaitForSeconds(1);
    }
}
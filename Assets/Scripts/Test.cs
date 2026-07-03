using System.Collections;
using System.Reflection;
using Uniject;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Enemy[] _enemiesPrefabs;

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
        // Container.Bind<TContract>().To<TConcrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy().AsEntryPoint();
        // container.BindPool<TContract>().WithInitialSize(8).ExpandBy*().To<TConcrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy();
        
        // var components = bufferPool.SpawnList<Component>();
        // bufferPool.DespawnList(components);

        // var components = bufferPool.SpawnArray<Component>(10);
        // bufferPool.DespawnArray(components);

        // var components = bufferPool.SpawnHash<Component>();
        // bufferPool.DespawnHash(components);

        // var components = bufferPool.SpawnDictionary<Component>();
        // bufferPool.DespawnDictionary(components);

        var container = new Container();
        container.BindFactory<Enemy, Enemy.Pool, Enemy.Pool.Factory>().FromFactory<Enemy.Pool.CustomFactory>().AsCached();
        
        // container.Bind<Enemy>()
        //     .FromNewComponentOnNewGameObject()
        //     .AsCached();
        
        // container.BindPool<Enemy, Enemy.Pool>()
        //     .WithInitialSize(4)
        //     .WithMaxSize(6)
        //     .ExpandByDoubling()
        //     .To<Enemy>()
        //     .FromNewComponentOnNewGameObject()
        //     .AsCached();

        Build(container);

        yield return new WaitForSeconds(2f);

        var enemyPoolFactory = container.Resolve<Enemy.Pool.Factory>();
        var enemyPool1 = enemyPoolFactory.Create(_enemiesPrefabs[0]);
        var enemyPool2 = enemyPoolFactory.Create(_enemiesPrefabs[1]);
        
        yield return new WaitForSeconds(2f);

        var enemy1 = enemyPool1.Spawn();
        var enemy2 = enemyPool1.Spawn();
        var enemy3 = enemyPool2.Spawn();

        yield return new WaitForSeconds(2f);

        enemyPool1.Despawn(enemy1);
        enemyPool1.Despawn(enemy2);
    }
}
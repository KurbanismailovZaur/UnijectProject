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
        // Container.Bind<TContract>().To<TConcrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy().AsEntryPoint();
        // container.BindPool<TContract>().WithInitialSize(8).ExpandBy*().To<TConcrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy();
        
        // var enemy = enemyPool.GetObject();
        // enemyPool.TakeObject(enemy);

        var container = new Container();
        
        // container.Bind<Enemy>()
        //     .FromNewComponentOnNewGameObject()
        //     .AsTransient();
        
        container.BindPool<Enemy, Pool<Enemy>>()
            .WithInitialSize(3)
            .WithMaxSize(5)
            .ExpandByDoubling()
            .To<Enemy>()
            .FromFactory<Enemy.Factory>()
            .AsCached();;

        Build(container);

        yield return new WaitForSeconds(2f);

        var enemyPool = container.Resolve<Pool<Enemy>>();
        var enemy1 = enemyPool.Spawn();
        enemy1.Initialize();

        yield return new WaitForSeconds(2f);
        
        enemyPool.Despawn(enemy1);

        yield return new WaitForSeconds(2f);

        enemy1 = enemyPool.Spawn();

        yield return new WaitForSeconds(2f);
        var enemy2 = enemyPool.Spawn();

        yield return new WaitForSeconds(2f);
        var enemy3 = enemyPool.Spawn();

        yield return new WaitForSeconds(2f);
        var enemy4 = enemyPool.Spawn();

        yield return new WaitForSeconds(2f);
        var enemy5 = enemyPool.Spawn();

        yield return new WaitForSeconds(2f);

        enemyPool.Despawn(enemy1);
        enemyPool.Despawn(enemy2);
        enemyPool.Despawn(enemy3);
        enemyPool.Despawn(enemy4);
        enemyPool.Despawn(enemy5);
    }
}

public class SubTest : ISubTest
{
    public SubTest(string message, float pi, char character) => Debug.Log($"{message} {pi} {character}");
}

public interface ISubTest 
{
    
}

public class MyInstaller : IInstaller
{
    public void Install(Container container)
    {
        container.BindInstances('#');
        container.Bind<SubTest>();
    }
}
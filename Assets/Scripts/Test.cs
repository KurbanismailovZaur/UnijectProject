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
        
        container.Bind<Enemy>()
            .FromNewComponentOnNewGameObject()
            .AsTransient();
        
        container.BindPool<Enemy, Pool<Enemy>>()
            .WithInitialSize(3)
            .WithMaxSize(5)
            .ExpandByDoubling()
            .To<Enemy>()
            .FromResolve()
            .AsCached();;

        Build(container);

        yield return new WaitForSeconds(2f);

        var enemyPool = container.Resolve<Pool<Enemy>>();
        enemyPool.Spawn().Initialize();
        enemyPool.Spawn().Initialize();
        enemyPool.Spawn().Initialize();

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
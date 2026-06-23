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
        
        var subcontainer = new Container();
        subcontainer.BindInstances('#');
        subcontainer.Bind<SubTest>();

        var container = new Container();
        container.BindInstances("Hello from Uniject!", 3.1415f);
        container.Bind<Enemy>().FromNewComponentOnNewGameObject().AsTransient().NonLazy();
        container.Bind<SubTest>().FromSubcontainerResolve().ByInstance(subcontainer).AsCached();

        Build(container);

        yield return new WaitForSeconds(3f);

        container.Resolve<Enemy>();
        container.Resolve<Enemy>();

        yield return new WaitForSeconds(3f);

        container.Resolve<SubTest>();
        container.Resolve<SubTest>();
        container.Resolve<SubTest>();
    }
}

public class SubTest : ISubTest
{
    public SubTest(string message, float pi, char character) => Debug.Log($"{message} {pi} {character}");
}

public interface ISubTest 
{
    
}
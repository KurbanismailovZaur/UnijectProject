using System.Collections;
using System.Reflection;
using Uniject;
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
        // Container.Bind<Contract>().To<Concrete>().From*().WithObjectName().UnderTransform().AsScope().NonLazy().AsEntryPoint();
        var container = new Container();
        
        // container.Bind<TickableManager>().FromNewComponentOnNewGameObject().AsCached();
        // container.Bind<ClassWithEntryPoint>().AsEntryPoint();

        var t2 = container.Instantiate<Test2>();
        Debug.Log(t2.Container != null);
        
        ResolveNonLazyBindings(container);
        InjectQueuedInstances(container);
        CallEntryPoints(container);

        yield return new WaitForSeconds(1);
    }
}

public class Test2
{
    public Test2(Container container)
    {
        Container = container;
    }

    public Container Container { get; }
}
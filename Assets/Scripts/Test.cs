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

    private static void RunEntryPoints(Container container)
    {
        var method = typeof(Container).GetMethod("RunEntryPoints", BindingFlags.Instance | BindingFlags.NonPublic);
        method.Invoke(container, null);
    }

    private IEnumerator Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().WithGameObjectName().UnderTransform().AsScope().NonLazy().AsEntryPoint();
        // Container.BindFactory<TResult, TFactory>().To<TConcrete>().From*().AsScope();
        
        var container = new Container();

        container.Bind<IEnemy, Factory<IEnemy>>().To<Enemy>().FromFactory<Enemy.CustomFactory>().AsCached();

        ResolveNonLazyBindings(container);
        InjectQueuedInstances(container);
        RunEntryPoints(container);


        var fact1 = container.Resolve<Factory<IEnemy>>();
        var fact2 = container.Resolve<Factory<IEnemy>>();

        Debug.Log($"Factory 1 {fact1.GetHashCode()}");
        Debug.Log($"Factory 2 {fact2.GetHashCode()}");

        fact1.Create().Initialize();
        fact1.Create().Initialize();
        fact2.Create().Initialize();
        fact2.Create().Initialize();

        

        yield return new WaitForSeconds(1);
    }
}
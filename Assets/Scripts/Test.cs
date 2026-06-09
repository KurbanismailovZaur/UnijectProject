using System.Collections;
using Uniject;
using Uniject.Tests;
using Uniject.Tests.Fixtures;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;

    private IEnumerator Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().AsScope().NonLazy();

        var container = new Container();
        container.Bind<Script>().FromNewComponentOnNewGameObject().WithObjectName("Zaur").UnderTransform(_characterPrefab.transform).AsTransient();

        container.Resolve<Script>();
        container.Resolve<Script>();

        yield return null;
    }
}

public class Foo<T>
{
    public int Value { get; set; }
}

public class Bar
{
    public Bar(Foo<int> foo) { }
}
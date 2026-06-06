using System.Collections;
using Uniject;
using Uniject.Tests;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;

    private IEnumerator Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().AsScope().NonLazy();

        var container = new Container();
        container.Bind<Class>().To<Class>().FromComponentInNewPrefab(new GameObject());

        yield return null;
    }
}
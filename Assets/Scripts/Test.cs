using System.Collections;
using Uniject;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;

    private IEnumerator Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().AsScope().NonLazy();
        // Container.Bind<IPlayer>().To<IPlayer>().FromNew().AsTransient();

        // Container.Bind<GameObject>().From
        // Container.Bind<Character>().From
        // Container.Bind<ICharacter>().From

        var container = new Container();
        container.Bind<ICharacter>().To<ICharacter>().FromComponentInNewPrefab(_characterPrefab).AsCached().NonLazy();
        container.Bind<Enemy>();

        // container.Bind<GameObject>().To<GameObject>().FromComponentInNewPrefab(_characterPrefab.gameObject);
        // container.Bind<Character>().To<Character>().FromComponentInNewPrefab(_characterPrefab);
        // container.Bind<ICharacter>().To<ICharacter>().FromComponentInNewPrefab(_characterPrefab);

        container.Resolve<ICharacter>().Move();
        container.Resolve<ICharacter>().Move();
        Debug.Log("Instantiating Character prefab...");

        yield return null;
    }
}
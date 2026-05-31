using Uniject;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;

    private void Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().AsScope().NonLazy();

        // Container.Bind<IPlayer>().To<IPlayer>().FromNew().AsTransient();

        var container = new Container();
        container.Bind<ICharacter>().To<Character>().FromComponentInNewPrefab(_characterPrefab).AsCached().NonLazy();
        container.Bind<Enemy>();

        // container.Resolve<Character>().Move();
        container.Resolve<ICharacter>().Move();
        Debug.Log("Instantiating Character prefab...");
        // container.Resolve<ICharacter>().Move();
        // container.Instantiate<Character>().Move();
    }
}
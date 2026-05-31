using Uniject;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        // Container.Bind<Contract>().To<Concrete>().From*().AsScope().NonLazy();

        // Container.Bind<IPlayer>().To<IPlayer>().FromNew().AsTransient();

        var container = new Container();
        container.Bind<Character>();
        container.Bind<Enemy>();

        // container.Resolve<Character>().Move();
        // container.Resolve<Character>().Move();
        // container.Resolve<Character>().Move();
        container.Instantiate<Character>().Move();
    }
}
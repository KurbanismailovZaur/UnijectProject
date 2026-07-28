using Uniject;
using Uniject.Installers;
using UnityEngine;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private Enemy _enemy;

    public override void Install(Container container)
    {
        container.BindFactory<Enemy, Enemy, Enemy.Factory>().FromMethod((container, prefab) =>
        {
            return null;
        });
    }
}
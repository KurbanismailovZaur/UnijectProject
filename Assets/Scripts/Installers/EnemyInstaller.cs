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
            var enemy = new GameObject("MyEnemy").AddComponent<Enemy>();
            container.Inject(enemy);
            var (context, parentTransform) = container.GetInfoAboutNearestParentForGameObjects();
            enemy.transform.SetParent(parentTransform);
            return enemy;
        });
    }
}
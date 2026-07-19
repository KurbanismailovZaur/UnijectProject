using System.IO;
using Uniject;
using Uniject.Contexts;
using Uniject.Installers;
using UnityEditor;
using UnityEngine;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private GameObjectContext _enemyContext;

    public override void Install(Container container)
    {
        container.BindInstance(_enemyPrefab);
        container.Bind<Enemy.Factory>().FromSubcontainerResolve().ByInstance(_enemyContext.Container);
        container.BindInstance(3.14f);

        container.Bind<ProjectController>().AsEntryPoint();
    }
}
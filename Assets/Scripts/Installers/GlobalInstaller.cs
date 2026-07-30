using System.IO;
using Uniject;
using Uniject.Contexts;
using Uniject.Installers;
using UnityEditor;
using UnityEngine;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private Enemy _enemy1;
    [SerializeField] private Enemy _enemy2;

    public override void Install(Container container)
    {
        container.Bind<Enemy>().FromComponentInHierarchy().AsCached();

        container.Bind<ProjectController>().AsEntryPoint();
    }
}
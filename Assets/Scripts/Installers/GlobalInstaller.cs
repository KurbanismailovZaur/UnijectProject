using System.IO;
using Uniject;
using Uniject.Contexts;
using Uniject.Installers;
using UnityEditor;
using UnityEngine;

public class GlobalInstaller : MonoInstaller
{
    public override void Install(Container container)
    {
        container.Bind<EnemyContainer>().AsCached();
        container.Bind<Enemy>().FromResolveGetter<EnemyContainer>(ec => ec.Enemy);
        container.Bind<ProjectController>().AsEntryPoint();
    }
}
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
        container.BindInstance(3.14f);
        container.Bind<ProjectController>().AsEntryPoint();
    }
}
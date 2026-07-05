using Uniject;
using Uniject.Installers;
using UnityEngine;

public class BootInstaller : MonoInstaller
{
    public override void Install(Container container)
    {
        container.Bind<BootSceneController>().AsEntryPoint();
    }
}
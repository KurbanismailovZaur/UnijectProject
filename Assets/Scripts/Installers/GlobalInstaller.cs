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
        container.Bind<float>().FromMethod(FloatGetter);
        container.Bind<ProjectController>().AsEntryPoint();
    }

    private float FloatGetter(Container container, InjectContext injectContext)
    {
        Debug.Log(injectContext.ConsumerInstance);
        Debug.Log(injectContext.ConsumerType);
        Debug.Log(injectContext.ContractType);
        Debug.Log(injectContext.ParameterInfo);

        return 3.14f;
    }
}
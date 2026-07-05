using Uniject;
using Uniject.Installers;
using UnityEngine;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private AudioClip[] _musicClips;
    [SerializeField] private MusicController _musicControllerPrefab;

    public override void Install(Container container)
    {
        container.BindInstance(new MusicClipsProvider(_musicClips));
        container.Bind<MusicController>().FromComponentInNewPrefab(_musicControllerPrefab)
            .WithGameObjectName(nameof(MusicController)).AsCached();

        container.Bind<ProjectController>().AsEntryPoint();
    }
}
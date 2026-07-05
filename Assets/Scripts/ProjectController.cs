using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class ProjectController : IEntryPoint
{
    private MusicController _musicController;

    public ProjectController(MusicController soundController)
    {
        _musicController = soundController;
    }

    public void Run()
    {
        Debug.Log("ProjectController is running!");

        _musicController.StartPlayRandomMusic();
    }
}
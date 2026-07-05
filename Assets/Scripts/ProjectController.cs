using Uniject;
using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class ProjectController : IEntryPoint
{
    private readonly MusicController _musicController;
    private readonly SceneLoader _sceneLoader;

    public ProjectController(MusicController soundController, SceneLoader sceneLoader)
    {
        _musicController = soundController;
        _sceneLoader = sceneLoader;
    }

    public void Run()
    {
        Debug.Log("ProjectController is running!");

        _musicController.StartPlayRandomMusics();
        _sceneLoader.LoadSceneAdditiveAsync(1);
    }
}
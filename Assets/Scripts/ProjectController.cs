using Uniject;
using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class ProjectController : IEntryPoint
{
    private readonly MusicController _musicController;
    private readonly SceneLoader _sceneLoader;
    private readonly Enemy.Factory _enemyFactory;
    private readonly Enemy _enemyPrefab;
    private readonly float _pi;

    public ProjectController(float pi)
    {
        _pi = pi;
    }

    public void Run()
    {
        Debug.Log("ProjectController is running!");
        Debug.Log(_pi);
    }
}
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

    public ProjectController(Enemy.Factory enemyFactory, Enemy enemyPrefab)
    {
        _enemyFactory = enemyFactory;
        _enemyPrefab = enemyPrefab;
    }

    public void Run()
    {
        Debug.Log("ProjectController is running!");

        _enemyFactory.Create(_enemyPrefab);
        _enemyFactory.Create(_enemyPrefab);
        _enemyFactory.Create(_enemyPrefab);
    }
}
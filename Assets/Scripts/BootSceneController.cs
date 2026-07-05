using System.Collections;
using Uniject;
using Uniject.Attributes;
using Uniject.Contexts;
using Uniject.Lifecycle;
using UnityEngine;

public class BootSceneController : IEntryPoint
{
    private readonly MusicController _musicController;
    private readonly SceneContext _sceneContext;
    private readonly float _pi;

    public BootSceneController(MusicController soundController, SceneContext sceneContext, float pi)
    {
        _musicController = soundController;
        _sceneContext = sceneContext;
        _pi = pi;
    }

    public void Run() => _sceneContext.StartCoroutine(RunEnumerator());

    private IEnumerator RunEnumerator()
    {
        Debug.Log("BootSceneController is running!");

        yield return new WaitForSeconds(3f);
        _musicController.StartPlayNextMusic();

        Debug.Log(_pi);
    }
}
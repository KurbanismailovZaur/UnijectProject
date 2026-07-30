using Uniject;
using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class ProjectController : IEntryPoint
{
    private readonly Enemy _enemy;

    public ProjectController(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Run()
    {
        Debug.Log("ProjectController is running!");
        Debug.Log(_enemy.name);
    }
}
using Uniject;
using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class ProjectController : IEntryPoint
{
    public ProjectController()
    {
    }

    public void Run()
    {
        Debug.Log("ProjectController is running!");
    }
}
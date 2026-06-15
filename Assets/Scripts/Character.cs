using Uniject.Attributes;
using Uniject.Lifecycle;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter, IEntryPoint
{
    public void Move()
    {
        Debug.Log($"Character {GetHashCode()} is moving");
    }

    public void Run()
    {
        Debug.Log("Script Started!");
    }
}
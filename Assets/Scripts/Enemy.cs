using Uniject;
using Uniject.Attributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float pi;

    [Inject]
    private void Construct(float pi) => this.pi = pi;

    public class Factory : Factory<Enemy, Enemy> { }
    public class Pool : Pool<Enemy> { }
}
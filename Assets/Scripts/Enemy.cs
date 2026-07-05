using Uniject;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public class Factory : Factory<Enemy> { }
}
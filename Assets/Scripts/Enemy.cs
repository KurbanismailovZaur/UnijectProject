using Uniject;
using Uniject.Attributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _pi;

    [Inject]
    private void Construct(float pi)
    {
        _pi = pi;
    }
}
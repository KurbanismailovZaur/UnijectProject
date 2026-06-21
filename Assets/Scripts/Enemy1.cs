using Uniject.Attributes;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private Enemy2 _enemy2;

    [Inject]
    private void Construct(Enemy2 enemy2)
    {
        _enemy2 = enemy2;
    }   
}
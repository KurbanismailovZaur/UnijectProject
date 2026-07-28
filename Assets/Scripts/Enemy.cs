using Uniject;
using Uniject.Attributes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Inject]
    private void Construct(EnemySpawner spawner)
    {
        
    }
}
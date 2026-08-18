using Uniject;
using Uniject.Attributes;
using UnityEngine;

public class EnemyContainer
{
    public Enemy Enemy => new GameObject("Enemy", typeof(Enemy)).GetComponent<Enemy>();
}
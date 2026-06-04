using Uniject.Attributes;
using UnityEngine;

public class Character : MonoBehaviour, ICharacter
{
    [Inject]
    public void Construct(Enemy1 enemy)
    {
        Debug.Log($"Character {GetHashCode()} created with enemy {enemy.GetHashCode()}");
    }

    public void Move()
    {
        Debug.Log($"Character {GetHashCode()} is moving");
    }

}
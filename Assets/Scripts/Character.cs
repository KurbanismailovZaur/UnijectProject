using UnityEngine;

public class Character : ICharacter
{
    public Character(Enemy enemy)
    {
        Debug.Log($"Character {GetHashCode()} created with enemy {enemy.GetHashCode()}");
    }

    public void Move()
    {
        Debug.Log($"Character {GetHashCode()} is moving");
    }

}
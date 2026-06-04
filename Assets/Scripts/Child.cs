using Uniject.Attributes;
using UnityEngine;

public class Child : MonoBehaviour
{
    [Inject]
    public void Construct(Enemy1 enemy)
    {
        Debug.Log($"Child {GetHashCode()} created with enemy {enemy.GetHashCode()}");
    }
}
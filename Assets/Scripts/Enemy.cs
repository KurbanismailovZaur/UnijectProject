using Uniject;
using Uniject.Attributes;
using UnityEngine;

class Enemy : MonoBehaviour, IEnemy
{
    public void Initialize() => Debug.Log($"Enemy {GetHashCode()} Initialized!");

    public class Factory : Factory<Enemy> { }

    public class CustomFactory1 : CustomFactory<Enemy>
    {
        public override Enemy Create() => _objectBuilder.AddComponent<Enemy>(new GameObject("Enemy"));
    }

    public class CustomFactory2 : CustomFactory<Enemy, Enemy>
    {
        public override Enemy Create(Enemy enemyPrefab) => _objectBuilder.Instantiate(enemyPrefab);
    }
}

public interface IEnemy
{
    void Initialize();
}
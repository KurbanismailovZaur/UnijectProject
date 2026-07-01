using Uniject;
using Uniject.Attributes;
using UnityEngine;

class Enemy : MonoBehaviour, IEnemy
{
    public int Health { get; set; } = 100;

    public void Initialize() => Debug.Log($"Enemy {GetHashCode()} Initialized!");

    public class Pool : Pool<Enemy>
    {
        protected override void Reset(Enemy enemy)
        {
            enemy.Health = 100;
        }
    }

    public class Factory : CustomFactory<Enemy>
    {
        public override Enemy Create()
        {
            var gameObject = new GameObject($"Enemy_{GetHashCode()}");
            return gameObject.AddComponent<Enemy>();
        }
    }
}

public interface IEnemy
{
    void Initialize();
}
using Uniject;
using Uniject.Attributes;
using UnityEngine;

class Enemy : MonoBehaviour, IEnemy
{
    public class Factory : Factory<Enemy>
    {
        
    }

    public class CustomFactory : IFactory<Enemy>
    {
        private Container _container;

        [Inject]
        private void Construct(Container container) => _container = container;

        Enemy IFactory<Enemy>.Create() => _container.AddComponent<Enemy>(new GameObject("Enemy"));
    }

    public void Initialize()
    {
        Debug.Log($"Enemy {GetHashCode()} Initialized!");
    }
}

public interface IEnemy
{
    void Initialize();
}
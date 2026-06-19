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
        private IObjectBuilder _objectBuilder;

        [Inject]
        private void Construct(IObjectBuilder objectBuilder) => _objectBuilder = objectBuilder;

        Enemy IFactory<Enemy>.Create() => _objectBuilder.AddComponent<Enemy>(new GameObject("Enemy"));
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
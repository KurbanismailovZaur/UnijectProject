using Uniject;
using Uniject.Attributes;
using UnityEngine;

class Enemy : MonoBehaviour, IEnemy
{
    public class Factory : Factory<Enemy> { }

    public class CustomFactory1 : IFactory<Enemy>
    {
        private IObjectBuilder _objectBuilder;

        [Inject]
        private void Construct(IObjectBuilder objectBuilder) => _objectBuilder = objectBuilder;

        public Enemy Create() => _objectBuilder.AddComponent<Enemy>(new GameObject("Enemy"));
    }

    public class CustomFactory2 : IFactory<Enemy, Enemy>
    {
        private IObjectBuilder _objectBuilder;

        [Inject]
        private void Construct(IObjectBuilder objectBuilder) => _objectBuilder = objectBuilder;

        public Enemy Create(Enemy enemyPrefab) => _objectBuilder.Instantiate(enemyPrefab);
    }

    public void Initialize() => Debug.Log($"Enemy {GetHashCode()} Initialized!");
}

public interface IEnemy
{
    void Initialize();
}
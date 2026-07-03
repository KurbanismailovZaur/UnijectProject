using Uniject;
using Uniject.InstanceGetters;
using UnityEngine;
using Uniject.Bindings.Pools;

class Enemy : MonoBehaviour, IEnemy
{
    public int Health = 100;

    public void Initialize() => Debug.Log($"Enemy {GetHashCode()} Initialized!");

    public class Pool : Pool<Enemy>
    {
        public class Factory : Factory<Enemy, Pool> { }

        public class CustomFactory : CustomFactory<Enemy, Pool>
        {
            public override Pool Create(Enemy prefab)
            {
                var pool = new Pool();
                pool.Initialize(
                    new InstanceGetterFromComponentInNewPrefab(_container, prefab, typeof(Enemy)), 
                    typeof(Enemy), 
                    4, 
                    6, 
                    ExpandType.ByDoubling);
                    
                return pool;
            }
        }

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
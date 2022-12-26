using ThroughMe.Entities;
using UnityEngine;

namespace ThroughMe.Spawners
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        public IObstacle Spawn(Obstacle value) =>
            Instantiate(value, CalculatePosition(), _container.rotation, _container);

        protected abstract Vector3 CalculatePosition();
    }
}
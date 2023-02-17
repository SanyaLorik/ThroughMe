using ThroughMe.Spawners;
using UnityEngine;

namespace ThroughMe.Entities
{
    public class ObstacleLauncher : MonoBehaviour
    {
        [SerializeField] private Obstacle[] _obstacles;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Transform _target;

        private void Awake()
        {
            // setup
            Launch();
        }

        private void Launch()
        {
            Obstacle obstacle = _spawner.Spawn(_obstacles[0]);
            obstacle.Move(_target.position);
            obstacle.LookAt(_target.position);
        }
    }
}
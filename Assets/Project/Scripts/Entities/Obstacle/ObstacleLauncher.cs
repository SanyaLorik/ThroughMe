using System;
using ThroughMe.Spawners;
using UnityEngine;

namespace ThroughMe.Entities
{
    public class ObstacleLauncher : MonoBehaviour
    {
        [SerializeField] private Obstacle[] _obstacles;
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Transform _target;
        [SerializeField] private Portal _portal;

        [Header("Setting obstacle")]
        [SerializeField][Range(0f, 0.5f)] private float _initialSpeed;
        [SerializeField][Range(0f, 1f)] private float _ratioStepAddingSpeed;

        private float _currentSpeed;

        private void Awake()
        {
            _currentSpeed = _initialSpeed;

            // setup
            Launch();
        }

        private void OnEnable()
        {
            _portal.OnCrossObstacle += OnLaunch;
            _portal.OnCrashed += OnRevertToInitialSpeed;
        }

        private void OnDisable()
        {
            _portal.OnCrossObstacle -= OnLaunch;
            _portal.OnCrashed -= OnRevertToInitialSpeed;
        }

        private void OnLaunch() =>
            Launch();

        private void OnRevertToInitialSpeed() =>
            _currentSpeed = _initialSpeed;

        private void Launch()
        {
            Obstacle obstacle = _spawner.Spawn(_obstacles[0]);
            obstacle.Init(_currentSpeed);
            obstacle.Move(_target.position);
            obstacle.LookAt(_target.position);

            RecaclulateSpeed();
        }

        private void RecaclulateSpeed() =>
            _currentSpeed += _currentSpeed * _ratioStepAddingSpeed;
    }
}
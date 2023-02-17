using Cysharp.Threading.Tasks;
using System;
using System.Threading;
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

        public event Action<int> OnSpeedUpdated;

        private CancellationTokenSource _tokenSource;

        private float _currentSpeed;
        private int _countSpeed = 1;

        private void Awake()
        {
            _currentSpeed = _initialSpeed;

            // setup
            Launch().Forget();
        }

        private void Start() =>
            OnSpeedUpdated?.Invoke(_countSpeed);

        private void OnEnable()
        {
            _portal.OnDied += OnStop;
            _portal.OnObstacleCrashed += OnRevertToInitialSpeed;
        }

        private void OnDisable()
        {
            _portal.OnDied -= OnStop;
            _portal.OnObstacleCrashed -= OnRevertToInitialSpeed;

            _tokenSource?.Cancel();
        }

        private void OnStop() =>
            _tokenSource?.Cancel();

        private void OnRevertToInitialSpeed()
        {
            _currentSpeed = _initialSpeed;
            _countSpeed = 1;

            OnSpeedUpdated?.Invoke(_countSpeed);
        }

        private async UniTaskVoid Launch()
        {
            _tokenSource = new CancellationTokenSource();
            CancellationToken token = _tokenSource.Token;

            do
            {
                Obstacle obstacle = _spawner.Spawn(_obstacles[0]);
                obstacle.Init(_currentSpeed);
                obstacle.Move(_target.position);
                obstacle.LookAt(_target.position);

                await UniTask.WaitUntil(() => obstacle == null, cancellationToken: token);

                OnSpeedUpdated?.Invoke(_countSpeed);

                RecaclulateSpeed();
            } 
            while (token.IsCancellationRequested == false);
        }

        private void RecaclulateSpeed()
        {
            _countSpeed++;
            _currentSpeed += _currentSpeed * _ratioStepAddingSpeed;
        }
    }
}
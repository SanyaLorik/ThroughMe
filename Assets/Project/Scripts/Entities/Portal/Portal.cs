using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Data _health;

        public event Action OnDied;
        public event Action OnObstacleCrashed;

        private int _currentHealth;

        private void Awake() =>
            _currentHealth = _health.Value;

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);

            _currentHealth--;
            if (_currentHealth <= 0)
            {
                Debug.Log("Died!");
                OnDied?.Invoke();
                return;
            }

            Debug.Log("Crashed!");
            OnObstacleCrashed?.Invoke();
        }

        private void OnTriggerEnter(Collider other) =>
            other.isTrigger = true;
    }
}
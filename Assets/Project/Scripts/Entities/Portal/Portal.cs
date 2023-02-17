using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Portal : MonoBehaviour
    {
        [SerializeField][Range(1, 10)] private int _health;

        public event Action OnDied;
        public event Action OnCrashed;
        public event Action OnCrossObstacle;

        private bool _isDead = false;

        private void OnCollisionEnter(Collision _)
        {
            if (_isDead == true)
                return;

            OnCrashed?.Invoke();

            _health--;
            if (_health <= 0)
                return;

            _isDead = true;

            Debug.Log("Died!");
            OnDied?.Invoke(); 
        }

        private void OnTriggerExit(Collider _)
        {
            if (_isDead == true)
                return;

            Debug.Log("Cross.");
            OnCrossObstacle?.Invoke();
        }
    }
}
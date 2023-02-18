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
        public event Action OnObstacleCrashed;

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(collision.gameObject);

            _health--;
            if (_health <= 0)
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
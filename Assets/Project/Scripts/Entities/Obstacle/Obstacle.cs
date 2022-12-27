using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField][Min(0)] private float _destoyAfterPortal;
        [SerializeField][Min(0)] private float _speed;

        private Rigidbody _rigidbody;

        private bool _isInvoked = false;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnTriggerEnter(Collider other) =>
            Collision(other.transform, _destoyAfterPortal);

        private void OnCollisionEnter(Collision collision) =>
            Collision(collision.transform);

        public Action PortalReached { private get; set; }

        public void Move(Vector3 target)
        {
            Vector3 direction = target - transform.transform.position;
            direction.Normalize();

            _rigidbody.velocity = direction * _speed;
        }

        public void LookAt(Vector3 target) =>
            transform.LookAt(target);

        private void Collision(Transform source, float time = 0)
        {
            if (source.GetComponent<IPortal>() is null)
                return;

            if (_isInvoked == false)
                PortalReached?.Invoke();

            _isInvoked = true;

            Destroy(gameObject, time);
        }
    }
}
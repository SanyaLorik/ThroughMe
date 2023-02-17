using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField][Min(0)] private float _destoyAfterPortal;
        [SerializeField][Min(0)] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        public void Move(Vector3 target)
        {
            Vector3 direction = target - transform.transform.position;
            _rigidbody.AddForce(direction * _speed, ForceMode.VelocityChange);
        }

        public void LookAt(Vector3 target) =>
            transform.LookAt(target);
    }
}
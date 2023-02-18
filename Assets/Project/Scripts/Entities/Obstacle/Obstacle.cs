using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Obstacle : MonoBehaviour
    {
        [SerializeField][Min(0)] private float _destoyAfterPortal;

        private Collider _collider;
        private Rigidbody _rigidbody;

        private float _speed;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _rigidbody = GetComponent<Rigidbody>();
            Destroy(gameObject, _destoyAfterPortal);
        }

        public bool IsTrigger => _collider.isTrigger;

        public void Init(float speed) =>
            _speed = speed;

        public void Move(Vector3 target)
        {
            Vector3 direction = target - transform.transform.position;
            _rigidbody.AddForce(direction * _speed, ForceMode.VelocityChange);
        }

        public void LookAt(Vector3 target) =>
            transform.LookAt(target);
    }
}
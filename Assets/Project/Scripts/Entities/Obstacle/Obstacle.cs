using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField] private AnimationCurve _curve;

        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        public void Move(Vector3 target)
        {

        }
    }
}
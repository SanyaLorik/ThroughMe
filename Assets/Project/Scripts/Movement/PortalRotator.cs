using ThroughMe.InputSystem;
using UnityEngine;

namespace ThroughMe.Movement
{
    public class PortalRotator : MonoBehaviour
    {
        [SerializeField] private MovementPortal _movement;
        [SerializeField] private Rigidbody _portal;
        [SerializeField] [Min(0)] private float _sensitivity;

        private void FixedUpdate()
        {
            if (_movement.Direction == Vector2.zero)
                return;

            Rotate();
        }

        private void Rotate()
        {
            float angle = _portal.rotation.eulerAngles.y + -_movement.Direction.x * _sensitivity;
            Quaternion quaternion = Quaternion.Euler(new Vector3(0, angle, 0));
            _portal.MoveRotation(quaternion);
        }
    }
}
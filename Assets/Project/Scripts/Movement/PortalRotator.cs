using ThroughMe.Entities;
using UnityEngine;
using Zenject;

namespace ThroughMe.Movement
{
    public class PortalRotator : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float _sensitivity;

        private IDirection _direction;

        [Inject]
        private void Construct(IDirection direction) =>
            _direction = direction;

        private void Update()
        {
            if (_direction.Direction == Vector2.zero)
                return;

            if (Portal == null)
                return;

            Rotate();
        }

        public IPortal Portal { private get; set; }

        private void Rotate()
        {
            float angle = Portal.Body.rotation.eulerAngles.y + -_direction.Direction.x * _sensitivity;
            Quaternion quaternion = Quaternion.Euler(new Vector3(0, angle, 0));
            Portal.Body.MoveRotation(quaternion);
        }
    }
}
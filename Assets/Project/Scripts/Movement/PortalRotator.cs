using ThroughMe.Entities;
using UnityEngine;
using Zenject;

namespace ThroughMe.Movement
{
    public class PortalRotator : MonoBehaviour
    {
        [SerializeField] private Transform _camera;

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
            float angle = -(Vector2.SignedAngle(Vector2.up, _direction.Direction) + _camera.eulerAngles.y);
            Quaternion quaternion = Quaternion.Euler(new Vector3(0, angle, 0));
            Portal.Body.MoveRotation(quaternion);
        }
    }
}
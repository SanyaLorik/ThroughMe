using ThroughMe.Movement;
using UnityEngine;

namespace ThroughMe.Entities
{
    public class PortalSwitcher : MonoBehaviour
    {
        [SerializeField] private Portal[] _portals;
        [SerializeField] private PortalRotator _rotator;

        private void Awake()
        {
            // setup
            Switch(0);
        }

        private int _index = 0;

        private void OnSwitchNext() =>
            Switch(1);

        private void OnSwitchBack() =>
            Switch(-1);

        private void Switch(int step)
        {
            _index = (_index + step) % _portals.Length;
            _rotator.Portal = _portals[_index];
        }
    }
}
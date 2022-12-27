using ThroughMe.InputSystem;
using ThroughMe.Movement;
using UnityEngine;
using Zenject;

namespace ThroughMe.Di
{
    public class InputSystemBinder : MonoInstaller
    {
        [SerializeField] private MovementPortal _joystick;

        public override void InstallBindings() =>
            BindDirection();

        private void BindDirection()
        {
            Container
                 .Bind<IDirection>()
                 .FromInstance(_joystick)
                 .AsCached()
                 .NonLazy();
        }
    }
}
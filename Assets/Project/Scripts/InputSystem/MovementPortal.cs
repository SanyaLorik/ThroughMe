using ThroughMe.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace ThroughMe.InputSystem
{
    [RequireComponent(typeof(Image))]
    public class MovementPortal : MonoBehaviour, IDirection
    {
        public Vector2 Direction => throw new System.NotImplementedException();
    }
}

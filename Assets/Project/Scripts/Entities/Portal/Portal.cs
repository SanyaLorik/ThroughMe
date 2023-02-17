using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Portal : MonoBehaviour, IPortal
    {
        public event Action OnCrashed;
        public event Action OnCrossObstacle;

        private void Awake() =>
            Body = GetComponent<Rigidbody>();

        public Rigidbody Body { get; private set; }
    }
}
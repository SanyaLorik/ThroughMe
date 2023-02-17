using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Portal : MonoBehaviour, IPortal
    {
        private void Awake() =>
            Body = GetComponent<Rigidbody>();

        public Rigidbody Body { get; private set; }



        public void OnCrashObstacle(Action method)
        {

        }

        public void OnCrossObstalce(Action method)
        {

        }
    }
}
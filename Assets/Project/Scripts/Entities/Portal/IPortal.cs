using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    public interface IPortal
    {
        Rigidbody Body { get; }

        void OnCrashObstacle(Action method);

        void OnCrossObstalce(Action method);
    }
}
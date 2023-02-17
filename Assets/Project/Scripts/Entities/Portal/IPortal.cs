using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    public interface IPortal
    {
        event Action OnCrashed;

        event Action OnCrossObstacle;

        Rigidbody Body { get; }
    }
}
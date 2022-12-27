using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    public interface IObstacle
    {
        Action PortalReached { set; }

        void Move(Vector3 target);
    }
}
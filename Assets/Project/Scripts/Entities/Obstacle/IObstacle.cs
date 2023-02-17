using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    public interface IObstacle
    {
        void Move(Vector3 target);

        void LookAt(Vector3 target);
    }
}
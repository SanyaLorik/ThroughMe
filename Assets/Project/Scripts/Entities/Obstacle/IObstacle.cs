using UnityEngine;

namespace ThroughMe.Entities
{
    public interface IObstacle
    {
        void Move(Vector3 target);
    }
}
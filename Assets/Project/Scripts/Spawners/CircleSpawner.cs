using System;
using UnityEngine;

namespace ThroughMe.Spawners
{
    public class CircleSpawner : Spawner
    {
        [SerializeField] private Transform _point;
        [SerializeField] private float _radius;

        protected override Vector3 CalculatePosition()
        {
            float angle = UnityEngine.Random.Range(0, 360);
            return new()
            {
                x = _radius * MathF.Cos(angle) + _point.position.x,
                y = _point.position.y,
                z = _radius * MathF.Sin(angle) + _point.position.z,
            };
        }
    }
}
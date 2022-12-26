using System;
using ThroughMe.Entities;
using UnityEngine;

namespace ThroughMe.Spawners
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _point;
        [SerializeField] private Transform _container;
        [SerializeField] private float _radius;

        private GameObject Spawn(GameObject value)
        {
            float angle = UnityEngine.Random.Range(0, 360);
            Vector3 position = new()
            {
                x = _radius * MathF.Cos(angle) + _point.position.x,
                y = _point.position.y,
                z = _radius * MathF.Sin(angle) + _point.position.z,
            };

            return Instantiate(value, position, _container.rotation, _container);
        }
    }
}
﻿using System;
using UnityEngine;

namespace ThroughMe.Entities
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField][Min(0)] private float _destoyAfterPortal;
        [SerializeField][Min(0)] private float _speed;

        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        public Action PortalReached { private get; set; }

        public void Move(Vector3 target)
        {
            Vector3 direction = target - transform.transform.position;
            _rigidbody.velocity = direction.normalized * _speed;
        }

        public void LookAt(Vector3 target) =>
            transform.LookAt(target);
    }
}
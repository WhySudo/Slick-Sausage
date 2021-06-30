using System;
using UnityEngine;

namespace Core.InputModule.Restrictors
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class SpeedThrowerRestriction : ForcerRestriction
    {
        public float minSpeedToThrow = 0.01f;
        private Rigidbody _rigidbody;
        private bool _activated = false;
        private bool _permited = false;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Activate()
        {
            _activated = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            _permited = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _permited = false;
        }

        public override bool Permited()
        {
            return (_rigidbody.velocity.magnitude < minSpeedToThrow || _permited) && _activated;
        }
    }
}
using System;
using UnityEngine;

namespace Core
{
    public class ObjectRotator : MonoBehaviour
    {
        public Vector3 rotSpeed;
        private void Update()
        {
            transform.Rotate(rotSpeed * Time.deltaTime);
        }
    }
}
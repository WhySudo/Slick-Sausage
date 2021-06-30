using UnityEngine;

namespace Core.LevelControl
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform followTransform;
        public float smoothTime = 0.3F;
        public bool setUpOffsetOnStart = false;
        public Vector3 requiredOffset;
        
        private Vector3 _velocity = Vector3.zero;
        
        private void Start()
        {
            if(setUpOffsetOnStart)requiredOffset = transform.position - followTransform.position ;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position - requiredOffset);
        }

        private void FixedUpdate()
        {
            var expectedPos = followTransform.position + requiredOffset;
            transform.position = Vector3.SmoothDamp(transform.position, expectedPos, ref _velocity, smoothTime);
        }
    }
}
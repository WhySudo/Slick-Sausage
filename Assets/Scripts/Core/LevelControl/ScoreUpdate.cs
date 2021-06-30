using UnityEngine;

namespace Core.LevelControl
{
    public class ScoreUpdate : MonoBehaviour
    {
        public TextDisplayer displayer;
        public Transform countedTransform;
        public float sensitivity;
        private Vector3 startPoint;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(startPoint, 0.3f);
        }

        private void Start()
        {
            startPoint = countedTransform.position;
        }

        private void Update()
        {
            var value = Mathf.Max(Mathf.RoundToInt((countedTransform.position - startPoint).x * sensitivity), 0);
            displayer.DisplayText(value.ToString());
        }
    }
}
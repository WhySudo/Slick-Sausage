using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(LineRenderer))]
    public class DirectionDrawerProcessor : InputForceProcessor
    {
        public float sensitivity = 0.5f;
        
        private LineRenderer _lineRenderer;
        protected override void OnInputEnded(Vector3 startPoint, Vector3 currentPoint, bool errored)
        {
            ClearLine();
        }

        protected override void OnInputBegan(Vector3 startPoint)
        {
            ClearLine();
        }

        protected override void OnInputProcessing(Vector3 startPoint, Vector3 currentPoint)
        {
            DrawLine(transform.position,  startPoint-currentPoint);
        }
        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void ClearLine()
        {
            _lineRenderer.positionCount = 0;
        }

        private void DrawLine(Vector3 begin, Vector3 offsetEnd)
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, begin);
            _lineRenderer.SetPosition(1, begin + offsetEnd * sensitivity);
        }

    }
}
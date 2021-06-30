using UnityEngine;

namespace Core
{
    public class DirectPositionForceProcessor : InputForceProcessor
    {
        public Rigidbody throwableObject;
        public float totalPower;
        public Vector3 axisCoefs;

        protected override void OnInputProcessing(Vector3 startPoint, Vector3 currentPoint)
        {
        }

        protected override void OnInputEnded(Vector3 startPoint, Vector3 currentPoint, bool errored)
        {
            if (errored) return;
            throwableObject.AddForce(CalculateDirectinon(startPoint, currentPoint), ForceMode.VelocityChange);
        }

        protected override void OnInputBegan(Vector3 startPoint)
        {
        }

        private Vector3 CalculateDirectinon(Vector3 startPoint, Vector3 currentPoint)
        {
            var direct = MultiVectors(FixAxis(startPoint - currentPoint), axisCoefs) * totalPower;
            return new Vector3(direct.x, Mathf.Sqrt(Mathf.Abs(2 * direct.y * Physics.gravity.y)), direct.z);
        }

        private Vector3 MultiVectors(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        private Vector3 FixAxis(Vector3 input)
        {
            return input.y < 0 ? new Vector3(input.x, -input.y, input.z) : input;
        }
    }
}
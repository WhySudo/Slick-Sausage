using UnityEngine;
using UnityEngine.Events;

namespace Core.InputModule.Events
{
    public class InputProcessedEvent : UnityEvent<InputProcessedArgs>
    {
    };

    public class InputProcessedArgs
    {
        public Vector3 startPoint;
        public Vector3 currentPoint;

        public InputProcessedArgs(Vector3 startPoint, Vector3 currentPoint)
        {
            this.startPoint = startPoint;
            this.currentPoint = currentPoint;
        }
    }
}
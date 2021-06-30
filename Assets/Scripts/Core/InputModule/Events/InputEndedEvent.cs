using UnityEngine;
using UnityEngine.Events;

namespace Core.InputModule.Events
{
    public class InputEndedEvent : UnityEvent<InputEndedArgs>
    {
    };

    public class InputEndedArgs
    {
        public Vector3 startPoint;
        public Vector3 currentPoint;
        public bool errored;
        public InputEndedArgs(Vector3 startPoint, Vector3 currentPoint, bool errored)
        {
            this.startPoint = startPoint;
            this.currentPoint = currentPoint;
            this.errored = errored;
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace Core.InputModule.Events
{
    public class InputBeganEvent : UnityEvent<InputBeganArgs>
    {
    };

    public class InputBeganArgs
    {
        public Vector3 startPoint;

        public InputBeganArgs(Vector3 startPoint)
        {
            this.startPoint = startPoint;
        }
    }
}
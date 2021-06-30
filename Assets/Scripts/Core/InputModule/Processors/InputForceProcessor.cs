using System;
using Core.InputModule.Events;
using UnityEngine;

namespace Core
{
    public abstract class InputForceProcessor : MonoBehaviour
    {
        public InputForcer forcer;


        protected abstract void OnInputBegan(Vector3 startPoint);
        protected abstract void OnInputEnded(Vector3 startPoint, Vector3 currentPoint, bool errored);
        protected abstract void OnInputProcessing(Vector3 startPoint, Vector3 currentPoint);

        private void OnEnable()
        {
            forcer.InputBeganEvent.AddListener(InputBegan);
            forcer.InputProcessedEvent.AddListener(InputProcessed);
            forcer.InputEndedEvent.AddListener(InputEnded);
        }

        private void InputBegan(InputBeganArgs arg0)
        {
            OnInputBegan(arg0.startPoint);
        }

        private void InputProcessed(InputProcessedArgs arg0)
        {
            OnInputProcessing(arg0.startPoint, arg0.currentPoint);
        }

        private void InputEnded(InputEndedArgs arg0)
        {
            OnInputEnded(arg0.startPoint, arg0.currentPoint, arg0.errored);
        }

        private void OnDisable()
        {
            forcer.InputBeganEvent.RemoveListener(InputBegan);
            forcer.InputProcessedEvent.RemoveListener(InputProcessed);
            forcer.InputEndedEvent.RemoveListener(InputEnded);
        }
    }
}
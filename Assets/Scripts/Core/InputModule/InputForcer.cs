using System;
using Core.InputModule;
using Core.InputModule.Controlers;
using Core.InputModule.Events;
using Core.InputModule.Restrictors;
using UnityEngine;

namespace Core
{
    public class InputForcer : MonoBehaviour
    {
        private const int InputProvider = 0; //Using only one touch
        
        public InputController controller;
        public ForcerRestriction restriction;

        public InputBeganEvent InputBeganEvent = new InputBeganEvent();
        public InputEndedEvent InputEndedEvent = new InputEndedEvent();
        public InputProcessedEvent InputProcessedEvent = new InputProcessedEvent();

        private Vector3 _startPoint;
        private bool _started = false;


        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (controller.GetAllClickProviders().Length == 0) return;
            var currentPoint = controller.GetClickScreenPos(InputProvider);
            if (!(restriction is null || restriction.Permited()))
            {
                OnClickUp(currentPoint, true);
                return;
            }
            if (controller.IsClickDown(InputProvider))
            {
                OnClickDown(currentPoint);
            }
            else if (controller.IsClickMoved(InputProvider))
            {
                OnClickMoved(currentPoint);
            }
            else if (controller.IsClickUp(InputProvider))
            {
                OnClickUp(currentPoint);
            }
        }

        private void OnClickDown(Vector3 currentPoint)
        {
            if (_started)
            {
                BadClickDetected();
                return;
            }

            _startPoint = currentPoint;
            _started = true;
            InputBeganEvent.Invoke(new InputBeganArgs(currentPoint));
            
        }

        private void OnClickMoved(Vector3 currentPoint)
        {
            if (!_started)
            {
                BadClickDetected();
                return;
            }

            InputProcessedEvent.Invoke(new InputProcessedArgs(_startPoint, currentPoint));
        }

        private void OnClickUp(Vector3 currentPoint, bool errored = false)
        {
            if (!_started)
            {
                BadClickDetected();
                return;
            }

            _started = false;
            InputEndedEvent.Invoke(new InputEndedArgs(_startPoint, currentPoint, errored));
        }

        private void BadClickDetected()
        {
            _startPoint = Vector3.zero;
            _started = false;
        }
    }
}
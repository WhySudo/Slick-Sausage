using Core.Events;
using UnityEngine;

namespace Core.WinLose
{
    [RequireComponent(typeof(Rigidbody))]
    public class RespawnOnRestart : MonoBehaviour
    {
        public WinLoseLinker winLoseLinker;

        private Vector3 _startPos;
        private Quaternion _startQuateration;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            var transform1 = transform;
            _startPos = transform1.position;
            _startQuateration = transform1.localRotation;
        }

        private void OnEnable()
        {
            winLoseLinker.RestartGameEvent.AddListener(OnGameRestarted);
        }

        private void OnDisable()
        {
            winLoseLinker.RestartGameEvent.RemoveListener(OnGameRestarted);
        }

        private void OnGameRestarted(RestartGameArgs arg0)
        {
            _rigidbody.MovePosition(_startPos);
            _rigidbody.MoveRotation(_startQuateration);
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            
        }
    }
}
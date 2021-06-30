using Core.Events;
using UnityEngine;

namespace Core.WinLose
{
    public class CloseOnRestart : MonoBehaviour
    {
        public WinLoseLinker winLoseLinker;
        public GameObject disabledObject;
        private void OnEnable()
        {
            winLoseLinker.RestartGameEvent.AddListener(OnGameRestarted);
        }
        private void OnDisable()
        {
            winLoseLinker.RestartGameEvent.RemoveListener(OnGameRestarted);
        }

        private void OnGameRestarted(RestartGameArgs restartGameArgs)
        {
            disabledObject.SetActive(false);
        }
    }
}
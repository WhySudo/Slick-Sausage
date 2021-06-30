using Core.Events;
using Core.WinLose;
using UnityEngine;

namespace Core.LevelControl
{
    public class WinLoseTimeFreeze : MonoBehaviour
    {
        public WinLoseLinker winLoseLinker;
        
        private void OnEnable()
        {
            Time.timeScale = 1;
            winLoseLinker.LoseEvent.AddListener(OnGameLost);
            winLoseLinker.RestartGameEvent.AddListener(OnGameRestarted);
            
        }

     
        private void OnDisable()
        {
            winLoseLinker.LoseEvent.RemoveListener(OnGameLost);
            winLoseLinker.RestartGameEvent.RemoveListener(OnGameRestarted);
        }

        private void FreezeTime()
        {
            Time.timeScale = 0;
        }
        private void UnfreezeTime()
        {
            Time.timeScale = 1;
        }
        private void OnGameLost(LoseArgs arg0)
        {
            FreezeTime();
        }
        private void OnGameRestarted(RestartGameArgs arg0)
        {
            UnfreezeTime();
        }

    }
}
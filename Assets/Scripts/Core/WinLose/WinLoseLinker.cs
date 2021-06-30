using Core.Events;
using UnityEngine;

namespace Core.WinLose
{
    [CreateAssetMenu(fileName = "winLoseConfig", menuName = "SceneLinkers/WinLoseLinker", order = 0)]
    public class WinLoseLinker : ScriptableObject
    {
        public LoseEvent LoseEvent = new LoseEvent();
        public WinEvent WinEvent = new WinEvent();
        public RestartGameEvent RestartGameEvent = new RestartGameEvent();
        public void Win()
        {
            WinEvent.Invoke(new WinArgs());
        }

        public void Lose()
        {
            LoseEvent.Invoke(new LoseArgs());
        }

        public void RestartGame()
        {
            RestartGameEvent.Invoke(new RestartGameArgs());
        }
        
    }
}
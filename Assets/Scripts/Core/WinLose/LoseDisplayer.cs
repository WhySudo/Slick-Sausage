using Core.Events;
using UnityEngine;

namespace Core.WinLose
{
    public class LoseDisplayer : MonoBehaviour
    {
        public WinLoseLinker winLoseLinker;
        public GameObject displayObject;
        private void OnEnable()
        {
            winLoseLinker.LoseEvent.AddListener(OnGameLose);
        }

        private void OnGameLose(LoseArgs arg0)
        {
            displayObject.SetActive(true);
        }

        private void OnDisable()
        {
            winLoseLinker.LoseEvent.RemoveListener(OnGameLose);
        }
    }
}
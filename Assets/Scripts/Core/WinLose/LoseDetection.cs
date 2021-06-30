using System;
using UnityEngine;

namespace Core.WinLose
{
    [RequireComponent(typeof(Collider))]
    public class LoseDetection : MonoBehaviour
    {
        public WinLoseLinker winLoseLinker;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<LoseZone>())
            {
                winLoseLinker.Lose();
            }
        }
    }
}
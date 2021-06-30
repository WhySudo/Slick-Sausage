using Core.InputModule;
using Core.InputModule.Restrictors;
using UnityEngine;

namespace Core.LevelControl
{
    public class StartUpActivator : MonoBehaviour
    {
        public CameraMovement cameraMovement;
        public GameObject startUpPanel;
        public GameObject scoreCounter;
        public SpeedThrowerRestriction restriction;
        public void StartupActivate()
        {
            cameraMovement.enabled = true;
            startUpPanel.SetActive(false);
            scoreCounter.SetActive(true);
            restriction.Activate();
        }
    }
}
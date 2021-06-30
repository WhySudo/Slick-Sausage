using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class TextDisplayer : MonoBehaviour
    {
        public Text displayedText;

        public void DisplayText(string text)
        {
            displayedText.text = text;
        }
    }
}
using UnityEngine;

namespace Core.InputModule.Restrictors
{
    public abstract class ForcerRestriction : MonoBehaviour
    {
        public abstract bool Permited();
    }
}
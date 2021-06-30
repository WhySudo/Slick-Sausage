using System;
using UnityEngine;

namespace DebugScripts
{
    public class BoundsDrawer : MonoBehaviour
    {
        public Bounds bounds;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var center = transform.position + bounds.center;
            Gizmos.DrawWireCube(center, bounds.extents*2);
        }
    }
}
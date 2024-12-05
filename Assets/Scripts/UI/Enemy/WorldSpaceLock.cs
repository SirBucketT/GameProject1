using UnityEngine;

namespace Enemy
{
    public class WorldSpaceLock : MonoBehaviour
    {
        public Transform cam;

        void LateUpdate()
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}

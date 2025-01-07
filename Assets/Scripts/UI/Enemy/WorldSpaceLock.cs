using UnityEngine;

namespace Enemy
{
    public class WorldSpaceLock : MonoBehaviour
    {
        [SerializeField] Transform cam;

        private void Awake()
        {
            cam = Camera.main.transform;
        }
        void LateUpdate()
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}

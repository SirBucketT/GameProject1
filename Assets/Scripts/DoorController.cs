using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] Animator anim;
    public bool IsOpen => anim.GetBool("IsOpen");

    [ContextMenu("Open Door")]
    public void OpenDoor()
    {
        anim.SetBool("IsOpen", true);
    }

    [ContextMenu("Close Door")]
    public void CloseDoor()
    {
        anim.SetBool("IsOpen", false);
    }
}

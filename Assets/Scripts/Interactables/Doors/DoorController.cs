using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public bool IsOpen => anim.GetBool("IsOpen");
    public bool PlayerIsWithinRange { get; private set; }


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
    
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        PlayerIsWithinRange = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        PlayerIsWithinRange = false;
    }

    public void OnDrawGizmos()
    {
        var color = PlayerIsWithinRange 
            ? Color.green
            : Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}

using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public DoorController doorController;
    
    public void Interact()
    {
        if (doorController.IsOpen)
        {
            doorController.CloseDoor();
        }
        else
        {
            doorController.OpenDoor();
        }
    }
}
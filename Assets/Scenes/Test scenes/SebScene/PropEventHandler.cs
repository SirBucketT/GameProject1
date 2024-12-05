using UnityEngine;
using UnityEngine.Events;

public class PropEventHandler : MonoBehaviour
{
    public UnityEvent onDisableEvent;
    private void Start()
    {
        onDisableEvent ??= new UnityEvent();
    }

    private void TriggerDisableEvent()
    {
        Debug.Log("Disable event triggered!");
        onDisableEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerDisableEvent();
        }
    }
}
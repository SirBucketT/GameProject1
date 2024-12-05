using UnityEngine;
using UnityEngine.Events;

public class PropEventHandler : MonoBehaviour
{
    public UnityEvent onCollisonEvent;
    private void Start()
    {
        onCollisonEvent ??= new UnityEvent();
    }

    private void TriggerDisableEvent()
    {
        Debug.Log("Disable event triggered!");
        onCollisonEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerDisableEvent();
        }
    }
}
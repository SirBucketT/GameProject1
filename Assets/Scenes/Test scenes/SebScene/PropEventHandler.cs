using UnityEngine;
using UnityEngine.Events;

public class PropEventHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _playerInteractKet= KeyCode.D;
    
    public UnityEvent onCollisionEvent;
    public UnityEvent onKeyPressEvent;
    private bool isPlayerInRange = false;  
    private bool isKeyPressed = false;     
    private void Start()
    {
        onCollisionEvent ??= new UnityEvent();
        onKeyPressEvent ??= new UnityEvent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_playerInteractKet))
        {
            isKeyPressed = true;
            TriggerKeyPressEvent();
        }
    }

    private void TriggerCollisionEvent()
    {
        Debug.Log("Collision event triggered!");
        onCollisionEvent.Invoke();
    }

    private void TriggerKeyPressEvent()
    {
        Debug.Log("Key press event triggered!");
        onKeyPressEvent.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerCollisionEvent();
        }
    }
}
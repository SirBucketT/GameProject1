using UnityEngine;
using UnityEngine.Events;

public class PropEventHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _playerInteractKet = KeyCode.D;
    private PlayerIsWithinRange _playerIsWithinRange;
    
    public UnityEvent onCollisionEvent;
    public UnityEvent onKeyPressEvent;

    private void Start()
    {
        onCollisionEvent ??= new UnityEvent();
        onKeyPressEvent ??= new UnityEvent();
        _playerIsWithinRange =Object.FindAnyObjectByType<PlayerIsWithinRange>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_playerInteractKet))
        {
            TriggerKeyPressEvent();
        }
    }
    private void TriggerKeyPressEvent()
    {
        if (_playerIsWithinRange != null && _playerIsWithinRange.IsPlayerWithinRange())
        {
            Debug.Log("Key press event triggered!");
            onKeyPressEvent.Invoke();
        }
        else
        {
            Debug.Log("Player is not in range!");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerCollisionEvent();
        }
    }
    
    private void TriggerCollisionEvent()
    {
        Debug.Log("Collision!");
        onCollisionEvent.Invoke();
    }
    
}
using UnityEngine;

public class DisabableObject : MonoBehaviour
{
    [SerializeField] private bool _isObjectDisablable;
    [SerializeField] private bool _isObjectDisabledOnKeyPress;

    public void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (_isObjectDisablable)
        {
            DeactivateObject();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && _isObjectDisabledOnKeyPress)
        { 
            DeactivateObject();
        }
    }
    
    private void DeactivateObject()
    {
        this.gameObject.SetActive(false);
        Debug.Log("Object deactivated");
    }
}
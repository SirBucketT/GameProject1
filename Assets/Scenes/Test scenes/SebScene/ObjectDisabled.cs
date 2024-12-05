using UnityEngine;

public class ObjectDisable : MonoBehaviour
{
    [SerializeField] private bool _isObjectDisabled;

    public void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (_isObjectDisabled)
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
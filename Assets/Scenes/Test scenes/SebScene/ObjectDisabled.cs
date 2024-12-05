using UnityEngine;

public class ObjectDeactivate : MonoBehaviour
{
    [SerializeField] private bool _isObjectDisabled;   // Whether the object should be disabled on collision.

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
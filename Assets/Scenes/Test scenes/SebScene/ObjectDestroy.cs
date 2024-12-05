using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] private bool _isObjectDestroyed;  // Whether the object should be destroyed on collision.

    public void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (_isObjectDestroyed)
        {
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
        Debug.Log("Object Destroyed");
    }
}
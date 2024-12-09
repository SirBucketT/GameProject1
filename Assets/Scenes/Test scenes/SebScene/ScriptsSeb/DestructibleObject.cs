using UnityEngine;
public class DestructibleObject : MonoBehaviour
{
    [SerializeField] private bool _isObjectDestroyable;
    [SerializeField] private bool _isObjectDestroyedOnKeyPress;
    public void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (_isObjectDestroyable)
        {
            DestroyObject();
        }
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && _isObjectDestroyedOnKeyPress)
        { 
            DestroyObject();
        }
    }
    
    private void DestroyObject()
    {
        if (gameObject.activeInHierarchy)
        {
            Destroy(this.gameObject);
        Debug.Log("Object Destroyed");
        }
    }
}
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] private so_ObjectDestroyData settings;  

    public void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        switch (settings.isDisabledOnContact)
        {
            case true when !settings.isDestroyedOnContact:
                this.gameObject.SetActive(false);
                Debug.Log("Object deactivated");
                break;
            case false when settings.isDestroyedOnContact:
                Destroy(this.gameObject);
                Debug.Log("Object Destroyed");
                break;
        }
    }
}
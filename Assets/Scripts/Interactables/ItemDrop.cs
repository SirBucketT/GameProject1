using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody itemRigidBody;

    [SerializeField] private float dropForce = 5f; 

    void Start()
    {
        itemRigidBody = GetComponent<Rigidbody>();

        if (itemRigidBody == null)
        {
            itemRigidBody = gameObject.AddComponent<Rigidbody>();
        }
        
        itemRigidBody.AddForce(Vector3.up * dropForce, ForceMode.Impulse);
    }
    
}
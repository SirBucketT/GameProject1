using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    
    public float rotationSpeed = 180f;

    void Update()
    {
        
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}

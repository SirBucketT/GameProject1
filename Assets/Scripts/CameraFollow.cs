using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    [SerializeField] float camSpeed = 2.0f;

    public void Awake()
    {
        offset = transform.position;
    }

    public void LateUpdate()
    {
        if (target == null)
            return;
        
        var desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, camSpeed * Time.deltaTime);
        
    }
}



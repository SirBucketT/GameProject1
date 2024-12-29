using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
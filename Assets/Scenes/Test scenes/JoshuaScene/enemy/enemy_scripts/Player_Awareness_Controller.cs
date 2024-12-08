using UnityEngine;

public class Player_Awareness_Controller : MonoBehaviour
{
    public bool AwareOfPlayer { get; set; }
    public Vector2 DirectionToPlayer { get; set; }

    [SerializeField]
    private float playerAwarenessDistance;

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if (enemyToPlayerVector.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}

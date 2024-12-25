using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer2 : MonoBehaviour
{
    private NavMeshAgent _agent;

    public delegate void PlayerSighted(GameObject player);
    public PlayerSighted OnPlayerSighted;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        OnPlayerSighted = OnPlayerSight;
    }
    void OnPlayerSight(GameObject player)
    {
        _agent.SetDestination(player.transform.position);
        // Man kanske kan skapa en sfär som collidar med Player, och startar attack på avstånd?
    }
}

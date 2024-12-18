using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private float detectionRange;
    private NavMeshAgent _navMeshAgent;
    
    public Transform player;  
    public NavMeshAgent enemyAgent;  
    
    void Update()
    {
        var distanceToPlayer = Vector3.Distance(player.position, enemyAgent.transform.position);
        if (distanceToPlayer <= enemyAgent.stoppingDistance)
        { 
            EnemySwingLeft();
        }
        else
        {
            _animator.SetBool("IsPlayerClose", false);
        }
    }
    
    [ContextMenu("EnemySwingLeft")]
    public void EnemySwingLeft()
    {
        _animator.SetBool("IsPlayerClose", true);
    }

    [ContextMenu("EnemySwingStop")]
    public void EnemySwingRight()
    {
        _animator.SetBool("IsPlayerClose", false);
    }
}

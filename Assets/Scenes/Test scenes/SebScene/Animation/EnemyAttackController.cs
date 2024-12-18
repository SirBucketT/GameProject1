using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    private NavMeshAgent _navMeshAgent;
    
    private Transform _player;  
    private NavMeshAgent _enemyAgent;  
    
    void Update()
    {
        var distanceToPlayer = Vector3.Distance(_player.position, _enemyAgent.transform.position);
        if (distanceToPlayer <= _enemyAgent.stoppingDistance)
        {
            _animator.SetBool("IsPlayerClose", true);
            Debug.Log($"Enemy attack anmation is on");
        }
        else
        {
            _animator.SetBool("IsPlayerClose", false);
            Debug.Log($"Enemy attack animation is off");
        }
    }
}

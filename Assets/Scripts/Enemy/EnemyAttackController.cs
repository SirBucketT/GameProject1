using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject _weapon;
    [SerializeField] float _attackRange;
    [SerializeField] PlayerData _playerData;
    private bool hasSwung = false; 
    private Transform _player;
    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (_weapon != null)
        {
            _animator = _weapon.GetComponent<Animator>();
        }
    }
    private void Update()
    {
        if (!_player || _playerData.currentHealth <= 0)
        {
            EnemySwingStop();
            return;
        }

        float distanceToPlayer = Vector3.Distance(_player.position, transform.position);

        if (distanceToPlayer < _attackRange)
        {
            if (!hasSwung)
            {
                EnemySwing();
            }
        }
        else
        {
            if (!hasSwung) return;
            EnemySwingStop();
        }
    }
    [ContextMenu("EnemySwing")]
    public void EnemySwing()
    {
        _animator.SetBool("IsPlayerClose", true);
        hasSwung = true;
    }
    
    [ContextMenu("EnemySwingStop")]
    public void EnemySwingStop()
    {
        _animator.SetBool("IsPlayerClose", false);
        hasSwung = false;  
    }
}

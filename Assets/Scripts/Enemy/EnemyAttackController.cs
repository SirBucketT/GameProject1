using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private float _cooldownTime;
    [SerializeField] PlayerData _playerData;
    [SerializeField] private bool _hasBoomerang = false;
    [SerializeField] private bool _hasBonk = false;
    
    private Transform _player;
    private float _nextAttackTime;
    private Collider _weaponCollider;
    private NavMeshAgent _navMeshAgent;
    internal bool IsAttacking;

    private readonly string[] _attackTriggers = { "Attack", "BonkAttack", "BoomerangAttack" };
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _weaponCollider = _weapon?.GetComponent<Collider>();
        _animator = _weapon?.GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _nextAttackTime = Time.time;
    }
    
    private void Update()
    {
        if (IsPlayerAlive())
        {
            DistanceCheck();
        }
        else if (_player)
        {
            ResetAllAttacks();
        }
    }
    
    private void DistanceCheck()
    {
        if (HasStoppedMoving())
        {
            if (!IsAttackOnCooldown())
            {
                PerformAttack();
            }
        }
        else
        {
            ResetAllAttacks();
        }
    }
    
    private void PerformAttack()
    {
        if (_hasBonk)
        {
            TriggerAttack("BonkAttack");
        }
        else if (_hasBoomerang)
        {
            TriggerAttack("BoomerangAttack");
        }
        else
        {
            TriggerAttack("Attack");
        }

        IsAttacking = true;
        EnableWeaponCollision();
        _nextAttackTime = Time.time + _cooldownTime;
    }

    private bool IsAttackOnCooldown()
    {
        return Time.time >= _nextAttackTime;
    }
    private void TriggerAttack(string attackTrigger)
    {
        _animator.SetTrigger(attackTrigger);
    }

    private void ResetAllAttacks()
    {
        foreach (string trigger in _attackTriggers)
        {
            _animator.ResetTrigger(trigger);
        }
        
        DisableWeaponCollision();
        IsAttacking = false;
    }

    private void EnableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = true;
        }
    }

    private void DisableWeaponCollision()
    {
        if (_weaponCollider)
        {
            _weaponCollider.enabled = false;
        }
        
    }
    private bool HasStoppedMoving()
    {
        return _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_navMeshAgent.pathPending;
    }
    
    private bool IsPlayerAlive()
    {
        return _player && _playerData.currentHealth >= 0;
    }
}

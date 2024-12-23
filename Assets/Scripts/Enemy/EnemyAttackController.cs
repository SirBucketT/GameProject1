using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject _weapon;
    [SerializeField] float _attackRange;
    [SerializeField] private float _cooldownTime;
    [SerializeField] PlayerData _playerData;
    [SerializeField] private bool HasBoomerang = false;
    [SerializeField] private bool HasBonk = false;

    private Transform _player;
    private float _nextAttackTime;
    private Collider _weaponCollider;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _weaponCollider = _weapon?.GetComponent<Collider>();
        _animator = _weapon?.GetComponent<Animator>();
        
        _nextAttackTime = Time.time;
    }
    
    private void Update()
    {
        if (_player && _playerData.currentHealth > 0)
        {
            DistanceCheck();
        }
        else
        {
            StopAllAttacks();
        }
    }

    private void DistanceCheck()
    {
        float distanceToPlayer = Vector3.Distance(_player.position, transform.position);

        if (distanceToPlayer < _attackRange && Time.time >= _nextAttackTime)
        {
            PerformAttack();
        }
        else if (distanceToPlayer >= _attackRange)
        {
            StopAllAttacks();
        }
    }

    private void PerformAttack()
    {
        if (HasBonk)
        {
            _animator.SetTrigger("AttackBonk");
        }
        else if (HasBoomerang)
        {
            _animator.SetTrigger("AttackBoomerang");
        }
        else
        {
            _animator.SetTrigger("Attack");
        }

        EnableWeaponCollision();
        _nextAttackTime = Time.time + _cooldownTime;
    }

    private void StopAllAttacks()
    {
        _animator.ResetTrigger("Attack");
        _animator.ResetTrigger("BonkAttack");
        _animator.ResetTrigger("BoomerangAttack");
        DisableWeaponCollision();
    }

    private void EnableWeaponCollision()
    {
        if (_weaponCollider != null)
        {
            _weaponCollider.enabled = true;
        }
    }

    private void DisableWeaponCollision()
    {
        if (_weaponCollider != null)
        {
            _weaponCollider.enabled = false;
        }
    }
}

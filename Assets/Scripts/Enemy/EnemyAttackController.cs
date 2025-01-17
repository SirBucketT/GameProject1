using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private Animator _bodyAnimator;
    [SerializeField] private PlayerData _playerData;
    [Header("Attack settings")]
    [SerializeField] private Animator _weaponAnimator;
    [SerializeField] private GameObject _weapon;
    [SerializeField, Range(1.5f, 10f)] private float _cooldownTime;
    [SerializeField] private bool _hasBoomerang = false;
    [SerializeField] private bool _hasBonk = false;
    
    private Transform _player;
    private Collider _weaponCollider;
    private NavMeshAgent _navMeshAgent;
    private bool IsAttacking;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
        _weaponCollider = _weapon?.GetComponent<Collider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (EnemyCanAttack())
        {
            IsAttacking = true;
            Debug.Log(IsAttacking);
            StartCoroutine(PerformAttack());
        }
    }

    private IEnumerator PerformAttack()
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

        EnableWeaponCollision();
        StartCoroutine(WaitForAttackCooldown());
        
        yield break;
    }

    private IEnumerator WaitForAttackCooldown()
    {
        yield return new WaitForSeconds(_cooldownTime); 
        DisableWeaponCollision();
        RotateToPlayer();
        IsAttacking = false;
        Debug.Log(IsAttacking);
    }

    private void TriggerAttack(string attackTrigger)
    {
        if (_weaponAnimator != null)
        {
            _weaponAnimator.SetTrigger(attackTrigger);
        }

        if (_bodyAnimator != null)
        {
            _bodyAnimator.SetTrigger(attackTrigger);
        }
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
    private void RotateToPlayer()
    {
        Vector3 direction = _player.transform.position - transform.position;
         
        direction.y = 0;
         
        transform.rotation = Quaternion.LookRotation(direction);
    }
    private bool EnemyCanAttack()
    {
        return IsPlayerAlive() && HasStoppedMoving() && !IsAttacking;
    }

    private bool HasStoppedMoving()
    {
        return _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_navMeshAgent.pathPending;
    }

    private bool IsPlayerAlive()
    {
        return _player != null && _playerData.currentHealth > 0;
    }
}

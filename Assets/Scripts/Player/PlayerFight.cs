using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Animator _animator;
    private EnemyHealthManager _enemyHealth;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive", true);
    }
    void Update()
    {
        
        if (_animator.GetBool("LockedEnemy") && Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetTrigger("Dab");
        }
        if (_animator.GetBool("LockedEnemy") && Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetTrigger("Kick"); 
        }
        if (_animator.GetBool("LockedEnemy") && Input.GetKeyDown(KeyCode.E))
        {
            _animator.SetTrigger("Slash");
        }
    }
    
    
}
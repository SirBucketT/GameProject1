using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsAlive", true);

    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetTrigger("Dab");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetTrigger("Kick"); 
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("Slash");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetTrigger("JumpSpin");
        }
        
    }
}
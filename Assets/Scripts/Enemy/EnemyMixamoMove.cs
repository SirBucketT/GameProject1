using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMixamoMove: MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent;
    private Animator _animator;
    private float _normalizedSpeed;

    private void Awake()
    { 
        _normalizedSpeed = _agent.velocity.magnitude / _agent.speed / 2;
    }
    void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _target = player.transform;
            }
        }
    }
    
    private void Update()
    {
        
        if (_target != null)
        {
            _agent.SetDestination((_target.position));
            _animator.SetFloat("Velocity", _normalizedSpeed);
        }
    }
}
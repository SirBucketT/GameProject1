using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    RaycastHit _hitInfo;
    NavMeshAgent _agent;
    private Animator _animator;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float normalizedSpeed = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("Velocity", normalizedSpeed);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out _hitInfo)) // Single Click
            {
                Vector3 directionToHit = (_hitInfo.point - transform.position).normalized;
                _agent.SetDestination(_hitInfo.point);
            }
        }


        if (Input.GetMouseButton(0)) // Hold
        {
            if (Physics.Raycast(ray.origin, ray.direction, out _hitInfo))
            {
                _agent.SetDestination(_hitInfo.point);
            }
        }
    }
    

}
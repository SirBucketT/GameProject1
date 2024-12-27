using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _agent.transform.position) > 0.01f)
        {
            _agent.transform.position = transform.position;
        }

        float normalizedSpeed = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("Velocity", normalizedSpeed);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) // Single click or hold
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
            }
        }
    }
}

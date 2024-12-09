using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    RaycastHit hitInfo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        animator.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                agent.destination = hitInfo.point;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                agent.destination = hitInfo.point;
            }
        }
    }
}
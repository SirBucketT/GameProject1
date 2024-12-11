using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    RaycastHit hitInfo;
    NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float normalizedSpeed = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Velocity", normalizedSpeed);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) // Single Click
            {
                agent.destination = hitInfo.point;
            }
        }

        if (Input.GetMouseButton(0)) // Hold
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                agent.destination = hitInfo.point;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("Sword");
        }
    }
}
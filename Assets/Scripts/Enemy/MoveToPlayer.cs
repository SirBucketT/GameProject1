using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination((target.position));
        }
    }
}

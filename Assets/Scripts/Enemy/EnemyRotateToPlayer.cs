using System;
using UnityEngine;

public class EnemyRotateToPlayer : MonoBehaviour
{
    private Transform target;
    private EnemyAttackController attacker;
    public void Awake()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
        }
        attacker = GetComponent<EnemyAttackController>(); 
    }

    
 
    void Update()
    {
        RotateToPlayer();

    }

    private void RotateToPlayer()
    {
       if(IsEnemyNotAttacking())
        {
            Vector3 direction = target.position - transform.position;
         
            direction.y = 0;
         
            transform.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            return;
        }
        
    }

    private bool IsEnemyNotAttacking()
    {
        return attacker.IsAttacking;
    }
}

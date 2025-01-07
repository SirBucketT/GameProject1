using System;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
          
           private Animator animator;

           private void Start()
           {
               animator.GetComponent<Animator>();
               
           }

           public void GetKicked()
    {
        animator.SetTrigger("EnemyGetHit");
    }
}

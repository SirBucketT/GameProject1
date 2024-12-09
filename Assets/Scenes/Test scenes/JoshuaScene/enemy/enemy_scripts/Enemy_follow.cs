using UnityEngine;

public class Enemy_follow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Animator anim;
    public float range;
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     anim.SetBool("isRunning", false);
    //     float distance = range;
    //     float dist = Vector3.Distance(enemy.transform.position, player.position); // Input player var next to .posistion
    //
    //     if (dist <= distance)
    //     {
    //         anim.SetBool("isRunning", true);
    //         enemy.SetDestination(player.position);
    //         AttackPlayer();
    //     }
    // }
}

using UnityEngine;

public class PlayerMovementSMB : StateMachineBehaviour
{
    // Called when entering the state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // You can initialize some variables here if needed
    }

    // Called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Here we can handle animation transitions or logic based on the Velocity parameter
        float velocity = animator.GetFloat("Velocity");

        if (velocity == 0)
        {
            // Idle animation
            animator.Play("Idle");
        }
        else if (velocity > 0 && velocity < 0.5f)
        {
            // Walking animation
            animator.Play("Walking");
        }
        else
        {
            // Running animation
            animator.Play("Running");
        }
    }

    // Called when the state ends
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // You can perform any cleanup here if needed
    }
}
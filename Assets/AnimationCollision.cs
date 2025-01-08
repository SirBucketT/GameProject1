using UnityEngine;

public class AttackCollision : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var _longsword = animator.GetComponent<LongSword>();

        if (stateInfo.IsName("Great Sword Slash"))
        {
            _longsword.EnableWeaponCollision();
        }
        else if (stateInfo.IsName("Great Sword Kick"))
        {
            _longsword.EnableFootCollision();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var _longsword = animator.GetComponent<LongSword>();

        if (stateInfo.IsName("Great Sword Slash"))
        {
            _longsword.DisableWeaponCollision();
        }
        else if (stateInfo.IsName("Great Sword Kick"))
        {
            _longsword.DisableFootCollision();
        }
    }
}
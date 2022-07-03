using UnityEngine;

public class ResetPosition : StateMachineBehaviour
{
    private static readonly int Hit = Animator.StringToHash("hit");

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Rigidbody2D>().MovePosition(Vector2.zero);
        animator.ResetTrigger(Hit);
    }

}

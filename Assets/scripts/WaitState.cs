using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : StateMachineBehaviour
{
   
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<playerScript>().closestToBall == true)
        {
            animator.SetBool("chaseBall", true);
            return;
        }
        else if(animator.GetComponent<playerScript>().supportPlayer==true)
        {
            animator.SetBool("support", true);
            return;
        }
        else if(animator.GetComponent<playerScript>().outOfPosition==true)
        {
            animator.SetBool("outOfPosition", true);
            return;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
}

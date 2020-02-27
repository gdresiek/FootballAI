using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportState : StateMachineBehaviour
{

    private GameObject team;
    private GameObject playerClosestToBall;
    private Vector3 direction;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        team = GameObject.FindGameObjectWithTag("TeamController");
        if (animator.GetComponent<playerScript>().teamNumber == 1)
        {

            playerClosestToBall = team.GetComponent<teamScript>().playerClosestToBall1;
        }
        else if (animator.GetComponent<playerScript>().teamNumber == 2)
        {

            playerClosestToBall = team.GetComponent<teamScript>().playerClosestToBall2;
        }
        direction = ( playerClosestToBall.transform.position- animator.transform.position ).normalized;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        direction = (playerClosestToBall.transform.position - animator.transform.position).normalized;
        if (animator.GetComponent<playerScript>().supportPlayer==false)
        {
            animator.SetBool("support", false);
        }
        else if(Vector3.Distance(animator.transform.position,playerClosestToBall.transform.position)>15)
        {
            animator.GetComponent<Rigidbody>().AddForce(direction*animator.GetComponent<playerScript>().speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else
        {
            //wait
        }
        
    }

   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}

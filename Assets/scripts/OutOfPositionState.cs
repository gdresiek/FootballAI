using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPositionState : StateMachineBehaviour
{

    private playerScript player;
    private Vector3 regionDirection;
    private GameObject region;
    private float speed;
    private GameObject ball;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        player = animator.GetComponent<playerScript>();

        
        speed = player.speed;
        regionDirection = (player.checkCurrentRegion().position - player.transform.position).normalized;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        regionDirection = (player.checkCurrentRegion().position - player.transform.position).normalized;
        if (player.closestToBall==true)
        {
            animator.SetBool("outOfPosition", false);
            return;
        }
        if (player.outOfPosition == false)
        {
            animator.SetBool("outOfPosition", false);
            return;
        }
        else
        {
            player.GetComponent<Rigidbody>().AddForce(regionDirection * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}

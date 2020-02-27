using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBallState : StateMachineBehaviour

{
    private Transform ballPosition;
    private GameObject ball;
    //private GameObject team;
    private float speed;
    private GameObject player;
    private Vector3 ballDirection;

    private float ballDistance; //distance to ball

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        ball= GameObject.FindGameObjectWithTag("Ball");
        speed = player.GetComponent<playerScript>().speed;
        ballPosition = GameObject.FindGameObjectWithTag("Ball").transform;
        ballDistance = Vector3.Distance(ballPosition.position, player.transform.position);

        ballDirection = (ballPosition.position - player.transform.position).normalized;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.GetComponent<playerScript>().closestToBall == false)
        {
            animator.SetBool("chaseBall", false);
            return;
        }
        //chase ball
        //player.transform.position = Vector3.MoveTowards(player.transform.position, ballPosition.position, speed*Time.deltaTime);
        player.GetComponent<Rigidbody>().AddForce(ballDirection * speed*Time.deltaTime, ForceMode.VelocityChange);
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    animator.SetBool("chaseBall", false);
        //}

        //update ball distance
        ballDistance = Vector3.Distance(ballPosition.position, player.transform.position);
        ballDirection = (ballPosition.position - player.transform.position).normalized;
        if (ballDistance < 1.2) //&& player.GetComponent<playerScript>().ableToKick==true)
        {
            
            //Debug.Log("Here");
            animator.SetBool("kickBall", true);
            return;
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}

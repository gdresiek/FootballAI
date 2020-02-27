using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBallState : StateMachineBehaviour
{
    private Rigidbody ball;
    private GameObject goal;
    private GameObject team;
    private GameObject supportPlayer1;
    private GameObject supportPlayer2;

    private Vector3 kickDirection;
    private Vector3 dribbleDirection;
    private Vector3 passDirection;
    private float kickPower;
    private float dribblePower;
    private float passPower;
    public GameObject player;
    private ballScript ballCheck;
    private float stealChance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        stealChance = 30.0f;
        player = animator.gameObject;
        ballCheck = GameObject.FindGameObjectWithTag("Ball").GetComponent<ballScript>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        team = GameObject.FindGameObjectWithTag("TeamController");

        if (animator.GetComponent<playerScript>().teamNumber == 1)
        {
            goal = GameObject.FindGameObjectWithTag("Goal2");
            supportPlayer1 = team.GetComponent<teamScript>().supportPlayer1attack;
            supportPlayer2 = team.GetComponent<teamScript>().supportPlayer1defence;
        }
        else if (player.GetComponent<playerScript>().teamNumber == 2)
        {
            goal = GameObject.FindGameObjectWithTag("Goal1");
            supportPlayer1 = team.GetComponent<teamScript>().supportPlayer2attack;
            supportPlayer2 = team.GetComponent<teamScript>().supportPlayer2defence;
        }
        Debug.Log(ball);
        Debug.Log(ballCheck);

        //dribble/shoot/pass


        if (Random.Range(0.0f, 100.0f) < stealChance || ballCheck.possesion == 0 || ballCheck.possesion == player.GetComponent<playerScript>().teamNumber)//ballCheck.onTheGround == true &&)
        {
            ball.velocity = Vector3.zero;
            if (player.GetComponent<playerScript>().ableToKick == true && Vector3.Distance(player.transform.position, goal.transform.position) < 20)
            {

                shoot();
            }
            else if (player.GetComponent<playerScript>().threatened == true)
            {

                pass();
                //animator.SetBool("kickBall", false);


            }
            else
            {

                dribble();
            }
            //set ball possession to current team
            ballCheck.possesion = player.GetComponent<playerScript>().teamNumber;
        }




        //exit to wait state
        animator.SetBool("kickBall", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void shoot()
    {
        ball.AddForce(countKickDirection() * kickPower, ForceMode.Impulse);
    }
    void dribble()
    {
        ball.AddForce(countDribbleDirection() * dribblePower, ForceMode.Impulse);
    }
    void pass()
    {
        ball.AddForce(countPassDirection() * passPower, ForceMode.Impulse);
    }
    Vector3 countPassDirection()
    {
        GameObject supportPlayer;
        if (Random.Range(0.0f, 100.0f) < 45)
            supportPlayer = supportPlayer2;
        else
            supportPlayer = supportPlayer1;
        //supportPlayerHighPassPos = new Vector3(supportPlayerHighPassPos.x, supportPlayerHighPassPos.y + 8, supportPlayerHighPassPos.z);
        passDirection = (supportPlayer.transform.position - ball.transform.position).normalized;
        //passDirection= new Vector3(passDirection.x , passDirection.y + 40, passDirection.z).normalized;

        //kickDirection = new Vector3(kickDirection.x + Random.Range(-10.2f, 10.2f), kickDirection.y + Random.Range(100.2f, 120.2f), kickDirection.z + Random.Range(-10.2f, 10.2f)).normalized;
        passPower = 25.0f; //+ Random.Range(-5f, 5.0f);

        return passDirection;
    }
    Vector3 countDribbleDirection()
    {
        dribbleDirection = goal.transform.position - ball.transform.position;
        dribbleDirection = new Vector3(dribbleDirection.x, dribbleDirection.y, dribbleDirection.z + Random.Range(-20f, 20.0f)).normalized;

        dribblePower = 5;
        return dribbleDirection;
    }

    Vector3 countKickDirection()
    {
        kickDirection = goal.transform.position - ball.transform.position;
        //randomize kick
        //low kick
        kickDirection = new Vector3(kickDirection.x + Random.Range(-4.2f, 4.2f), kickDirection.y + Random.Range(-2.2f, 5.2f), kickDirection.z + Random.Range(-4.2f, 4.2f)).normalized;
        //high kick
        //kickDirection = new Vector3(kickDirection.x + Random.Range(-10.2f, 10.2f), kickDirection.y + Random.Range(100.2f, 120.2f), kickDirection.z + Random.Range(-10.2f, 10.2f)).normalized;

        kickPower = player.GetComponent<playerScript>().kickPower + Random.Range(-4.0f, 8.0f);



        return kickDirection;
    }
}

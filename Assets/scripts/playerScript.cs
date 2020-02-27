using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    private GameObject ball;
    private GameObject goal;
    public float ballDistance;
    public bool ableToKick;
    public float kickTime;
    public float speed;
    public float kickPower;
    public bool closestToBall=false;
    public int teamNumber;
    public bool threatened;
    public GameObject regionDefend;
    public GameObject regionAttack;
    public bool outOfPosition;
    public bool supportPlayer;
    private GameObject team;


    // Start is called before the first frame update
    void Start()
    {

      

        kickTime = 5.0f;
        speed = 40;
        kickPower = 20;
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballDistance = Vector3.Distance(gameObject.transform.position, ball.transform.position);
        ableToKick = false;
        team = GameObject.FindGameObjectWithTag("TeamController");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject == team.GetComponent<teamScript>().supportPlayer1 || gameObject == team.GetComponent<teamScript>().supportPlayer2)
            supportPlayer = true;
        else
            supportPlayer = false;
        threatCheck();

        ballDistance = Vector3.Distance(gameObject.transform.position, ball.transform.position);
        if (ableToKick == false)
        {
            kickTime -= Time.deltaTime;
            if (kickTime < 0)
            {
                ableToKick = true;
                kickTime = 5;
            }
        }
        //check region
        if (Vector3.Distance(gameObject.transform.position, checkCurrentRegion().position) > 3)
        {
            outOfPosition = true;
        }
        else
            outOfPosition = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    //checks threat
    //    if(other.tag=="Team2")
    //    {
    //        threatened = true;
    //    }
        
       
        
    //}
    private void threatCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 2.5f) ;
        int i = 0;
        int threats = 0;
        while (i < hitColliders.Length)
        {
            if(teamNumber==1&&hitColliders[i].tag=="Team2")
            {
                threats++;
            }
            else if(teamNumber==2&&hitColliders[i].tag=="Team1")
            {
                threats++;
            }
            i++;
        }
        if (threats > 0)
        {
            threatened = true;
        }
        else
            threatened = false;
    }
    
    public Transform checkCurrentRegion()
    {
        
        if (ball.GetComponent<ballScript>().possesion == teamNumber)
            return regionAttack.transform;
        else
            return regionDefend.transform;

    }

}

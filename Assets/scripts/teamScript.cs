using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamScript : MonoBehaviour
{
    private GameObject[] team1;
    private GameObject[] team2;
    public GameObject playerClosestToBall1 = null;
    public GameObject playerClosestToBall2 = null;
    public GameObject supportPlayer1;
    public GameObject supportPlayer2;

    // Start is called before the first frame update
    void Start()
    {
        team1 = GameObject.FindGameObjectsWithTag("Team1");
        team2 = GameObject.FindGameObjectsWithTag("Team2");
        

        //looping through the team 1
        foreach(GameObject player in team1)
        {
            player.GetComponent<playerScript>().teamNumber = 1;
            //check for player closest to ball
            if (playerClosestToBall1 == null || player!=playerClosestToBall1 && player.GetComponent<playerScript>().ballDistance < playerClosestToBall1.GetComponent<playerScript>().ballDistance)
            {
                if (supportPlayer1 == null)
                    supportPlayer1 = player;
                if (playerClosestToBall1 != null)
                {
                    playerClosestToBall1.GetComponent<playerScript>().closestToBall = false;
                    
                }   
                playerClosestToBall1 = player;
                player.GetComponent<playerScript>().closestToBall = true; 
            }
            Debug.Log(player.name);
            //find support player
            if (player != playerClosestToBall1 && Vector3.Distance(player.transform.position, playerClosestToBall1.transform.position) < 20 && player.GetComponent<playerScript>().threatened == false)
            {
                supportPlayer1 = player;
            }
        }
        //looping through the team 2
        foreach (GameObject player in team2)
        {
            player.GetComponent<playerScript>().teamNumber = 2;
            //check for player closest to ball
            if (playerClosestToBall2 == null || player != playerClosestToBall2 && player.GetComponent<playerScript>().ballDistance < playerClosestToBall2.GetComponent<playerScript>().ballDistance)
            {
                if (supportPlayer2 == null)
                    supportPlayer2 = player;
                if (playerClosestToBall2 != null)
                {
                    playerClosestToBall2.GetComponent<playerScript>().closestToBall = false;
                    
                    
                }
                playerClosestToBall2 = player;
                player.GetComponent<playerScript>().closestToBall = true;
            }
            Debug.Log(player.name);
            //find support player
            if (player != playerClosestToBall1 && Vector3.Distance(player.transform.position, playerClosestToBall1.transform.position) < 20 && player.GetComponent<playerScript>().threatened == false)
            {
                supportPlayer2 = player;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // loop team 1
        foreach (GameObject player in team1)
        {
            //find support player
            if (supportPlayer1==null||player != playerClosestToBall1 && Vector3.Distance(player.transform.position, playerClosestToBall1.transform.position) < 20 && player.GetComponent<playerScript>().threatened == false)
            {
                //if (supportPlayer1 != null)
                    //player.GetComponent<playerScript>().supportPlayer = false; //uncheck previous support player in his script
                supportPlayer1 = player;
                //player.GetComponent<playerScript>().supportPlayer = true; //check new one 
            }
            //check for player closest to ball
            if (player != playerClosestToBall1 && player.GetComponent<playerScript>().ballDistance < playerClosestToBall1.GetComponent<playerScript>().ballDistance)
            {
                playerClosestToBall1.GetComponent<playerScript>().closestToBall = false;
                supportPlayer1 = playerClosestToBall1;
                //supportPlayer1.GetComponent<playerScript>().closestToBall = false;
                playerClosestToBall1 = player;
                player.GetComponent<playerScript>().closestToBall = true;
                //player.GetComponent<playerScript>().supportPlayer = false;

                if (player == supportPlayer1)
                    supportPlayer1 = null;
            }
            //Debug.Log(player.name);
            
        }
        // loop team 2
        foreach (GameObject player in team2)
        {
            if (supportPlayer2==null||player != playerClosestToBall2 && Vector3.Distance(player.transform.position, playerClosestToBall2.transform.position) < 20 && player.GetComponent<playerScript>().threatened == false)
            {
                //if (supportPlayer2 != null)
                    //player.GetComponent<playerScript>().supportPlayer = false; //uncheck previous support player in his script
                supportPlayer2 = player;
                //player.GetComponent<playerScript>().supportPlayer = true; //check new one 

            }
            //check for player closest to ball
            if (player != playerClosestToBall2 && player.GetComponent<playerScript>().ballDistance < playerClosestToBall2.GetComponent<playerScript>().ballDistance)
            {
                playerClosestToBall2.GetComponent<playerScript>().closestToBall = false;
                supportPlayer2 = playerClosestToBall2;
                playerClosestToBall2 = player;
                player.GetComponent<playerScript>().closestToBall = true;
                if (player == supportPlayer2)
                    supportPlayer2 = null;
            }
            //Debug.Log(player.name);
            //find support player
            
        }
    }
}

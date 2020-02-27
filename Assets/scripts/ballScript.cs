using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{

    private float distToGround;
    public bool onTheGround;
    public int possesion;
    private float possesionTime;
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        possesion = 0;
        onTheGround = true;
        //distToGround = 0;
        possesionTime = 1.5f;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(distToGround);
        
        
            // get the distance to ground
        
        if (gameObject.transform.position.y > 0.4)
        {
            onTheGround = false;

        }
        else
            onTheGround = true;
        //if (possesion != 0)
        //{
        //    possesionTime -= Time.deltaTime;
        //    if (possesionTime < 0)
        //    {
        //        possesion = 0;
        //        possesionTime = 1.5f;
        //    }
        //}



    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal1")
            gameController.scoreTeam2++;
        else if (collision.gameObject.tag == "Goal2")
            gameController.scoreTeam1++;
    }
}

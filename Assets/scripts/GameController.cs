using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    private float fixedDeltaTime;
    private GameObject ball;
    public int scoreTeam1;
    public int scoreTeam2;
    public Text score;
    public Text timer;
    private float time;
    private float minutes;
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
        Time.timeScale = 0.0f;
        ball = GameObject.FindGameObjectWithTag("Ball");
        time = 0.0f;
        float minutes = Mathf.Floor(time / 60);
        //float seconds = Mathf.RoundToInt(time % 60);
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        time += Time.deltaTime;
        float minutes = Mathf.Floor(time / 60);
        float seconds =time % 60;
        if (minutes<10&&seconds<10)
        {
            timer.text ="0"+ minutes.ToString() + ":0" + seconds.ToString("F2");
        }
        else if(minutes<10&&seconds>=10)
        {
            timer.text = "0"+minutes.ToString() + ":" + seconds.ToString("F2");
        }
        else if(seconds<10&&minutes>=10)
        {
            timer.text = minutes.ToString() + ":0" + seconds.ToString("F2");
        }
        else
            timer.text = minutes.ToString() + ":" + seconds.ToString("F2");

        score.text = scoreTeam1.ToString()+" : "+scoreTeam2.ToString();
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
            //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
        
    }

   
    
}

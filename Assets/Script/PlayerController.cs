using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody2D  rigidbody2D;
    public float speed;
    public float acceleration;
    public string prev_direction="None";
    public GameObject GameWonPanel; 
    public GameObject GameLostPanel; 
    private bool isGameOver=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetKey("space"));
        if( isGameOver == true || Input.GetKey("space")){
            speed=5;
            return;
        }

        /*if( Input.GetKeyDown("space") )
        {
            Debug.Log("Waiting for Space Key Up.");
            prev_direction="None";
        }*/

        else if(Input.GetAxis("Horizontal") > 0 )
        {
            if(prev_direction != "Right"){
                speed=5;
                rigidbody2D.velocity = new Vector2(speed, 0f);
            }            
            if(prev_direction == "Right"){
                speed*=acceleration;
                rigidbody2D.velocity = new Vector2(speed, 0f);
            }
            prev_direction = "Right";
        }  
        else if(Input.GetAxis("Horizontal") < 0 )
        {            
            if(prev_direction != "Left"){
                speed=5;
                rigidbody2D.velocity = new Vector2(-speed, 0f);
            }            
            if(prev_direction == "Left"){
                speed*=acceleration;
                rigidbody2D.velocity = new Vector2(-speed, 0f);
            }
            prev_direction = "Left";
        }
        else if(Input.GetAxis("Vertical") > 0 )
        {
            if(prev_direction != "Up"){
                speed=5;
                rigidbody2D.velocity = new Vector2( 0f, speed);
            }            
            if(prev_direction == "Up"){
                speed*=acceleration;
                rigidbody2D.velocity = new Vector2( 0f, speed);
            }
            prev_direction = "Up";
        }  
        else if(Input.GetAxis("Vertical") < 0 )
        {
            if(prev_direction != "Down"){
                speed=5;
                rigidbody2D.velocity = new Vector2( 0f , -speed);
            }            
            if(prev_direction == "Down"){
                speed*=acceleration;
                rigidbody2D.velocity = new Vector2( 0f , -speed);
            }
            prev_direction = "Down";
        }   
        else if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) 
        {
            rigidbody2D.velocity = new Vector2( 0f , 0f );
        } 
    }

     private void OnTriggerEnter2D(Collider2D other)
     {
         
         if(other.tag ==  "Door")
         {
            Debug.Log("Finish!");
            GameWonPanel.SetActive(true);
            isGameOver=true;
         }

         else if(other.tag ==  "Enemy")
         {
            Debug.Log("Level Lost!");
            GameLostPanel.SetActive(true);
            isGameOver=true;
         }
         
     }

     public void RestartGame() 
     {
         Debug.Log("Restarted!");
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
     }
}

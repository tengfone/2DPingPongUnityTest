using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //[SerializeField] 
    private float speed = 6f;

    private float radius;
    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // direction (1,1) normalized
        radius = transform.localScale.x / 2; // half the width
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction*speed*Time.deltaTime);
        
        // Bounce off top & bottom screen
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
        
        // Game Over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right Player Wins!");
            
            // Freeze and stop update
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player Wins!");
            
            // Freeze and stop update
            Time.timeScale = 0;
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;
            
            // If hit right paddle and move right, flip
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            
            // If hit left paddle and move right, flip
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}

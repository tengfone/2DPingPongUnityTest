using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //[SerializeField]
    public float speed = 10f;
    
    private float height;
    public bool isRight;
    private string input;
    
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        
        Vector2 pos = Vector2.zero;
        
        if (isRightPaddle)
        {
            // Place paddle on right of screen
            pos = new Vector2(GameManager.topRight.x,0);
            // Place offset to left , important to take note
            pos -= Vector2.right * transform.localScale.x;
            input = "PaddleRight";
        }
        else
        {
            // Place paddle on left side of screen
            pos = new Vector2(GameManager.bottomLeft.x,0);
            // Place offset to right, important to take note
            pos += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";
        }

        // Update the paddle position
        transform.position = pos;

        transform.name = input;

    }

    // Update is called once per frame
    void Update()
    {
        // move paddle, getaxis returns a number between -1(bottom) to 1(top)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // Restrict height
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        
        transform.Translate(move * Vector2.up);
    }
}
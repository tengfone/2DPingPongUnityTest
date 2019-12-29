using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    
    // Start is called before the first frame update
    void Start()
    {
        // Convert screen pixel coordinate to game coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        // Create ball
        Instantiate(ball);
        
        // Create paddle 
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        
        paddle1.Init(true); // right paddle
        paddle2.Init(false); // left paddle
    }
}

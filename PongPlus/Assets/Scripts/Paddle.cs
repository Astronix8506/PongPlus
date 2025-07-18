using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float id;
    public float movespeed = 2f;

    private void Update()
    {
        float value = ProcessInput();
        Move(value);
    }

    private float ProcessInput()
    {
        float movement = 0f;
        switch (id)
        {
            case 1:
                movement = Input.GetAxis("MovePlayer1");
                break;
            case 2:
                movement = Input.GetAxis("MovePlayer2");
                break;
        }
        
        return movement;
    }

    private void Move(float value)
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.y = movespeed * value;
        rb.linearVelocity = velocity;
    }
}

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    public float currentSpeed = 0;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    // Update is called once per frame
    /*void Update()
    {
        // Input on InputDetector
    }*/
    private void Awake()
    {
        
        InputDetector.OnInput += InputDetector_OnInput;

    }
    private void InputDetector_OnInput(InputData data)
    {
        float x = 0;
        float y = 0;
        switch (data.Input)
        {
            case InputType.Tap:
                currentSpeed = 0;
                break;
            case InputType.Up:
                y = 1;
                currentSpeed = speed;
                break;
            case InputType.Down:
                y = -1;
                currentSpeed = speed;
                break;
            case InputType.Right:
                x = 1;
                currentSpeed = speed;
                break;
            case InputType.Left:
                x = -1;
                currentSpeed = speed;
                break;
        }
        movement.x = x;
        movement.y = y;
        animator.SetFloat("Horizontal", x);
        animator.SetFloat("Vertical", y);
        animator.SetFloat("Speed", currentSpeed);
    }

    // FixedUpdate is called 50 times at second
    private void FixedUpdate()
    {
        // Movement
        Move();
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myrigidbody2D;

    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;
    public float speedRun;
    public float jumpForce;

    private float _currentSpeed;
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        // It also works for running mechanics 
        //myrigidbody2D.velocity = new Vector2(Input.GetKey(KeyCode.LeftShift) ? speedRun : speed, myrigidbody2D.velocity.y);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myrigidbody2D.MovePosition(myrigidbody2D.position - velocity * Time.deltaTime);
            myrigidbody2D.velocity = new Vector2(-_currentSpeed, myrigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myrigidbody2D.MovePosition(myrigidbody2D.position + velocity * Time.deltaTime);
            myrigidbody2D.velocity = new Vector2(_currentSpeed, myrigidbody2D.velocity.y);
        }

        if(myrigidbody2D.velocity.x < 0)
        {
            myrigidbody2D.velocity += friction;
        } 
        else if (myrigidbody2D.velocity.x > 0)
        {
            myrigidbody2D.velocity -= friction;
        }
    }

    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        myrigidbody2D.velocity = Vector2.up * jumpForce;
    }
}

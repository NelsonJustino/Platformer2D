using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myrigidbody2D;

    public Vector2 velocity;

    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myrigidbody2D.MovePosition(myrigidbody2D.position - velocity * Time.deltaTime);
            myrigidbody2D.velocity = new Vector2(-speed, myrigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myrigidbody2D.MovePosition(myrigidbody2D.position + velocity * Time.deltaTime);
            myrigidbody2D.velocity = new Vector2(speed, myrigidbody2D.velocity.y);
        }
    }
}

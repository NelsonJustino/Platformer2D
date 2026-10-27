using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myrigidbody2D;
    public GameObject ground;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    private float _currentSpeed;
    public float jumpForce;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .8f;
    public float groundScaleY = .8f;
    public float groundScaleX = 1.5f;
    public float animationDuration = .3f;
    private Ease ease = Ease.OutBack;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = Vector2.up * jumpForce;
            myrigidbody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myrigidbody2D.transform);

            PlayerJumpScale();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.tag == "Ground")
        {
            DOTween.Kill(myrigidbody2D.transform);
            PlayerOnGroundScale();
            myrigidbody2D.transform.localScale = Vector2.one;
        }
        else*/
        if(collision.gameObject.tag == "Elastic")
        {
            myrigidbody2D.transform.localScale = Vector2.one;
            DOTween.Kill(myrigidbody2D.transform);
            PlayerJumpScale();
        }
    }

    void PlayerJumpScale()
    {
        myrigidbody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myrigidbody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
    }
    
    /*void PlayerOnGroundScale()
    {
        myrigidbody2D.transform.DOScaleY(groundScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myrigidbody2D.transform.DOScaleX(groundScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }*/

}

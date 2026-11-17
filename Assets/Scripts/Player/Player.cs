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
    //private Ease ease = Ease.OutBack;

    [Header("Animation Trigger")]
    public string walkBool = "Bool_Walk";
    public string runBool = "Bool_Run";
    public string jumpUpBool = "Bool_Jump_Up";
    public string jumpDownBool = "Bool_Jump_Down";
    public string landingBool = "Bool_Landing";
    public string deathBool = "Bool_Death";

    private bool _isGrounded = true;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        JumpAnimation();
        CheckLandingAnimation();
    }

    void PlayerMovement()
    {
        bool isMoving = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning)
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            myrigidbody2D.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            myrigidbody2D.velocity = new Vector2(-_currentSpeed, myrigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myrigidbody2D.velocity = new Vector2(_currentSpeed, myrigidbody2D.velocity.y);
            myrigidbody2D.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (myrigidbody2D.velocity.x < 0)
        {
            myrigidbody2D.velocity += friction;
        }
        else if (myrigidbody2D.velocity.x > 0)
        {
            myrigidbody2D.velocity -= friction;
        }

        animator.SetBool(walkBool, _isGrounded && isMoving && !isRunning);
        animator.SetBool(runBool, _isGrounded && isMoving && isRunning);
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;

            myrigidbody2D.velocity = Vector2.up * jumpForce;

            animator.SetBool(jumpUpBool, true);
            animator.SetBool(jumpDownBool, false);
            animator.SetBool(landingBool, false);
        }
    }

    void JumpAnimation()
    {
        if (!_isGrounded)
        {
            if (myrigidbody2D.velocity.y > 0.1f)
            {
                animator.SetBool(jumpUpBool, true);
                animator.SetBool(jumpDownBool, false);
            }
            else
            {
                animator.SetBool(jumpUpBool, false);
                animator.SetBool(jumpDownBool, true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("PLAYER LANDED!");

            _isGrounded = true;

            animator.SetBool(jumpUpBool, false);
            animator.SetBool(jumpDownBool, false);
            animator.SetBool(landingBool, true);
        }
        if (collision.gameObject.CompareTag("Elastic"))
        {
            animator.SetBool(jumpUpBool, true);
            animator.SetBool(jumpDownBool, false);
            animator.SetBool(landingBool, false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool(deathBool, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void CheckLandingAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("ANIM_Astronaut_Jump_Landing") &&
            stateInfo.normalizedTime >= 1f)
        {
            animator.SetBool(landingBool, false);
        }

        if (stateInfo.IsName("ANIM_Astronaut_Death") &&
           stateInfo.normalizedTime >= 1f)
        {
            animator.SetBool(deathBool, false);
        }

    }

    /*void PlayerJumpScale()
    {
        myrigidbody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myrigidbody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
    }
    
    void PlayerOnGroundScale()
    {
        myrigidbody2D.transform.DOScaleY(groundScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myrigidbody2D.transform.DOScaleX(groundScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }*/
}

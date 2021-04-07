using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    bool facingRight = true;

    bool isGrounded;
    bool isPlatformed;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask IsGround;
    public LayerMask IsPlatform;
    public float jumpForce;

    bool isTouchingFront;
    public Transform frontcheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (!wallJumping)
            rb.velocity = new Vector2(input * speed, rb.velocity.y);
        
        if (isTouchingFront && !isGrounded && input != 0)
            wallSliding = true;
        else
            wallSliding = false;
        
        if (input > 0 && !facingRight)
            Flip();
        else if (input < 0 && facingRight)
            Flip();
        
        
        if (wallJumping)
        {
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
        }
    }
    // Update is called once per frame
    void Update()
    {

        /*
        if (input != 0)
        {
            //RunAnimations
        }
        else
        {
            //RunAnimations
        }
        */


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, IsGround);
        isPlatformed = Physics2D.OverlapCircle(groundCheck.position, checkRadius, IsPlatform);


        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || isPlatformed) && !wallJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            Debug.Log("Jumping");
        }

        if (!isGrounded)
        {
            //JumpAnimation
        }
        else
        {
            //JumpAnimation
        }

        isTouchingFront = Physics2D.OverlapCircle(frontcheck.position, checkRadius, IsGround);


        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallSliding)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public float speed = 5.0f;
    public int jumpForce = 300;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.02f;
    public bool isFalling;
    public bool isFiring;
    public bool isGroundSlaming;

    


    public Projectile projectile;
    public Transform projectileLaunchZone;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {

            speed = 5.0f;

        }
        if (jumpForce <= 0)
        {

            jumpForce = 300;

        }

        if(groundCheckRadius <= 0)
        {

            groundCheckRadius = 0.02f;
        }

        
    }

  
    private void OnValidate()
    {

        if (speed <= 0)
        {

            speed = 5.0f;

        }
        if (jumpForce <= 0)
        {

            jumpForce = 300;

        }

        if (groundCheckRadius <= 0)
        {

            groundCheckRadius = 0.02f;
        }


    }

    // Called in an AnimationEvent inside "Shoot"
    private void fireStar()
    {

        Instantiate(projectile, projectileLaunchZone.position, projectileLaunchZone.rotation);
        
    }

    private void setIsFiringFalse()
    {

        isFiring = false;

    }

    
    // Update is called once per frame
    void Update()
    {

 

        float hInput = Input.GetAxisRaw("Horizontal");
       

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        //Jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
            
        }

        Vector2 moveDirection = new Vector2(hInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("moveValue", Mathf.Abs(hInput));
        anim.SetBool("isGrounded", isGrounded);

       //Sprite Flipping
        if(hInput < 0 )
        {

            sr.flipX = true;

        }
        else
        {
            sr.flipX = false;
        }

        //Falling Animation
        if(rb.velocity.y < -0.1)
        {
            isFalling = true;
            anim.SetBool("isFalling", isFalling);
        }
        else
        {
            isFalling = false;  
            anim.SetBool("isFalling", isFalling);
        }


     
        //Shoot Star
        if(Input.GetButtonDown("Fire1") && !isFiring)
        {
            isFiring = true;
            anim.Play("Shoot");
                  
        }

        //Ground Slam
        if(!isGrounded && Input.GetKey("s") &&Input.GetButtonDown("Jump") && !isGroundSlaming  )
        {

            isGroundSlaming = true; //set in isGrounded
            anim.Play("GroundSlam");
            rb.gravityScale = 5f;

        }

        if (isGrounded)
        {
           rb.gravityScale = 1.6f;
           isGroundSlaming = false;
        }

        anim.SetBool("isGroundSlamming", isGroundSlaming);

    }
}

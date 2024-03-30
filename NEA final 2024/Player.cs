using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalMove = 0f; //horizontal move direction set
    public float speed = 40f; //player speed
    bool jump = false;
    public Animator animator;
    private Rigidbody2D rigidbody2D; //player rigidbody
    public bool facingRight = false; // Added semicolon
    private float jumpForce = 100f; //jump force
    public Transform playerFeet; //player foot
    public LayerMask groundLayer; 

    void Start()
    {
    rigidbody2D = GetComponent<Rigidbody2D>(); //gets the players rigidbody
    }

    void Update()
    {
        bool grounded = Physics2D.OverlapCircle(playerFeet.position, 0.2f, groundLayer);//checks is player is grounded
        if(grounded)
        {
            jump = false;
        }


        horizontalMove = Input.GetAxisRaw("Horizontal");//gets input from a/d and right/left keys
        Move(horizontalMove, jump);

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));//sets the animator to moving
        if (Input.GetButtonDown("Jump"))// checks for spacebar input
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));// applies a vertical force to the player
            animator.SetBool("jumping", true); //stes jump animation
        }
    }

    private void Move(float direction, bool jumping) // Added parameter types for both data types
    {
        if (direction != 0 && !jumping) // Replaced "and" with &&
        {
            Vector2 targetVelocity = new Vector2(direction * speed, rigidbody2D.velocity.y); // finds target velocity of player
            rigidbody2D.velocity = targetVelocity;//applies target velocity to player
        }

        if(facingRight == false && direction > 0) //if the player is facing left but moving right
        {
            Flip();
        }
        else if(facingRight == true && direction < 0) //if player is facing right but moving left
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;//change player direction
        Debug.Log("Flipped");

        Vector3 theScale = transform.localScale;//flips the player scale
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    private float horizontalMove;
    private bool isGrounded;
    private bool isCeiling;
  

    public Transform groundCheck;
    public Transform ceilingCheck;
    public float speed = 0;
    public float jumpSpeed = 10;
    public float slideSpeed = 10;

    public LayerMask grouneLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    
    void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        horizontalMove = speed; 
    }

    public void jumpButton()
    {
        isGrounded = Physics2D.OverlapCircle( groundCheck.position, 0.2f, grouneLayer );
        isCeiling = Physics2D.OverlapCircle( ceilingCheck.position, 0.2f, grouneLayer );
        
        if (isGrounded && !isCeiling)
        {
            ani.SetTrigger("jump");
            rb.velocity = Vector2.up * jumpSpeed;
           
        }
    }

    public void holdingSlideButton()
    {
        ani.SetTrigger("press_slide");
        rb.velocity = Vector2.down * slideSpeed;
    }
    
    public void notHoldingSlideButton()
    {
        ani.SetTrigger("no_press_slide");
        rb.velocity = Vector2.down * slideSpeed;
    }
    public void slideButton()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grouneLayer);

        if (isGrounded)
        {
            ani.SetTrigger("slide");
            rb.velocity = Vector2.down * slideSpeed;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}

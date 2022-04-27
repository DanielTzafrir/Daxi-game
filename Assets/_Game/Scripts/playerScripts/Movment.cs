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
    private bool isInfrontAWall;
    private bool isOnSpring;
    private bool springJumping = false;
    private bool springSwitch;
    private float stopRun = 0;

    public Transform groundCheck;
    public Transform ceilingCheck;
    public Transform WallCheck;
    public Transform WallCheck2;
    public Transform springCheck;
    public Transform springCheck2;
    public float speed = 0;
    public float jumpSpeed = 10;
    public float slideSpeed = 10;
    public List<GameObject> traps;
    public LayerMask grouneLayer;
    public LayerMask playerLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    
    void Update()
    {
        MovementPlayer();
        //spring up
        isOnSpring = Physics2D.OverlapCircle(springCheck.position, 0.2f, playerLayer) || Physics2D.OverlapCircle(springCheck2.position, 0.2f, playerLayer);
        if (isOnSpring)
        {
            spring();
            springJumping = true;
            Debug.Log("1");
        }

        if (springJumping)
        {
            Debug.Log("2");
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grouneLayer);
            if (rb.velocity.y < 0)
            {
                springDown();
                Debug.Log("3");
            }

            if (isGrounded)
            {
                Debug.Log("4");
                onGround();
                springJumping = false;
            }
        }
    }

    private void MovementPlayer()
    {
        isInfrontAWall = Physics2D.OverlapCircle(WallCheck.position, 0.2f, grouneLayer) || Physics2D.OverlapCircle(WallCheck2.position, 0.2f, grouneLayer);
        if (isInfrontAWall)
        {
            horizontalMove = stopRun;
        }
        else
        {
            horizontalMove = speed;
        }
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grouneLayer);

        if (isGrounded)
        {
            ani.SetTrigger("press_slide");
            rb.velocity = Vector2.down * slideSpeed;
        }
    }
    
    public void notHoldingSlideButton()
    {
        ani.SetTrigger("no_press_slide");
        rb.velocity = Vector2.down * slideSpeed;
    }

    private void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (traps.Contains(collider2D.gameObject))
        {
            takeDamage();
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        takeDamage();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {    
       ani.SetTrigger("onTrap");      
    }
    public void takeDamage()
    {
        ani.SetTrigger("onTrap");
    }

    public void spring()
    {
        ani.SetTrigger("spring");
    }

    public void springDown()
    {
        ani.SetTrigger("switchSpring");
    }
    public void onGround()
    {
        ani.SetTrigger("onground");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

}

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
    private float stopRun = 0;

    public Transform groundCheck;
    public Transform ceilingCheck;
    public Transform WallCheck;
    public Transform WallCheck2;
    public float speed = 0;
    public float jumpSpeed = 10;
    public float slideSpeed = 10;
    public List<GameObject> traps;
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
            StartCoroutine(ExampleCoroutine());
            ani.SetTrigger("jump");
        }
    }

    //wait in jump bcz of the animation
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.up * jumpSpeed;
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


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

}

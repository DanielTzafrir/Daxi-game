using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movment : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator ani;
    private float horizontalMove;
    private bool isGrounded;
    private bool isCeiling;
    private bool isInfrontAWall;
    private bool isOnSpring;
    private bool boosting;
    private float boostTimer;
    private float normalSpeed;
    private bool springJumping = false;
    private bool springSwitch;
    private bool changedRBGum = false;
    private float stopRun = 0;
    private bool gum = false;
    [SerializeField] private GameObject shield;
    [SerializeField] private float gravityUpGum;
    [SerializeField] private float gravityDownGum;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private Transform WallCheck2;
    [SerializeField] private Transform springCheck;
    [SerializeField] private Transform springCheck2;
    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpSpeed = 10;
    [SerializeField] private float slideSpeed = 10;
    [SerializeField] private LayerMask grouneLayer;
    [SerializeField] private LayerMask playerLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        isGrounded = true;
        boosting = false;
        boostTimer = 0;
        normalSpeed = speed;
    }

    void Update()
    {
        MovementPlayer();
        //spring up
        isOnSpring = Physics2D.OverlapCircle(springCheck.position, 0.1f, playerLayer) || Physics2D.OverlapCircle(springCheck2.position, 0.1f, playerLayer);
        if (isOnSpring)
        {
            spring();
            springJumping = true;
        }

        if (springJumping)
        {
            StartCoroutine(waitASec());            
        }

        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1f)
            {
                speed = normalSpeed;
                boostTimer = 0;
                boosting = false;
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grouneLayer);
    }

    IEnumerator waitASec()
    {
        yield return new WaitForSeconds(0.5f);

        if (rb.velocity.y < 0)
        {
            springDown();

        }

        if (isGrounded)
        {
            onGround();
            springJumping = false;

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
            if (!gum)
            {
                ani.SetTrigger("jump");
                rb.velocity = Vector2.up * jumpSpeed;
            }
        }
    }

    public void gumUp()
    {
        if (gum)
        {
            rb.gravityScale -= gravityUpGum;
        }
    }

    public void gumDown()
    {
        if (gum)
        {
            rb.gravityScale += gravityDownGum;
        }
    }

    public void holdingSlideButton()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grouneLayer);

        if (isGrounded && !gum)
        {
            Debug.Log("press_slide");
            ani.SetTrigger("start_sliding");
            ani.SetTrigger("press_slide");
            rb.velocity = Vector2.down * slideSpeed;
        }

    }
    
    public void notHoldingSlideButton()
    {
        if (!gum)
        {
            ani.SetTrigger("no_press_slide");
            StartCoroutine(stoptrigger());
            rb.velocity = Vector2.down * slideSpeed;
        }
    }

    private void OnTriggerEnter2D (Collider2D collider2D)
    {
        if (collider2D.tag == "Enemy" && !shield.activeSelf)
        {
            takeDamage();
        }

        else if (collider2D.tag == "speedBoost")
        {
            boosting = true;
            speed = speed * 1.6f;
        }
    }
    public void takeDamage()
    {
        //take damage = lose life, after that imuune for 3 secs.
        if (!gum)
        {
            ani.SetTrigger("onTrap");
        }
    }

    public void spring()
    {
        if (!gum)
        {
            ani.SetTrigger("spring");
        }
    }

    public void springDown()
    {
        if (!gum)
        {
            ani.SetTrigger("switchSpring");
        }
    }
    public void onGround()
    {
        if (!gum)
        {
            ani.SetTrigger("onground");
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        if (gum && !changedRBGum)
        {
            changedRBGum = true;
            rb.gravityScale = -0.5f;
            StartCoroutine(wait15sec());
        }
        else if (!gum)
        {
            changedRBGum = false;
            rb.gravityScale = 2.3f;
        }
    }

    public bool Gum
    {
        get
        {
            return this.gum;
        }
        set
        {
            gum = value;
        }
    }
    public float Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            speed = value;
        }
    }

    public bool Grounded
    {
        get
        {
            return this.isGrounded;
        }
        set
        {
            isGrounded = value;
        }
    }

    IEnumerator wait15sec()
    {
        yield return new WaitForSeconds(15);
        gum = false;
    }
    IEnumerator stoptrigger()
    {
        yield return new WaitForSeconds(0.5f);
        ani.ResetTrigger("no_press_slide");
    }
}

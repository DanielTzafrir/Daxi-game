using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float baseMoveSpeed = 5f;
    [SerializeField] private float moveSpeed; // Speed of player movement
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private CapsuleCollider2D bodyCollider;
    [SerializeField] private GameObject shield;
    private bool isOnGumEffect;
    private void Start()
    {
        moveSpeed = baseMoveSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
}

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        if(moveSpeed > baseMoveSpeed)
        {
            moveSpeed = baseMoveSpeed + moveSpeed / 2;
        }
    }
    public void JumpEvent()
    {
        if (isOnGumEffect)
            GumJump();
        else
            Jump();
    }

    public void GumEffect()
    {
        isOnGumEffect = true;        
        StartCoroutine(GumCoroutine());
        isOnGumEffect = false;
    }
    private void Jump()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground))
        {            
            animator.SetTrigger("jump");
            rigidBody.velocity = Vector2.up * jumpSpeed;
        }
    }

    private void GumJump()
    {
        rigidBody.gravityScale = -0.5f;
    }

    public void SlideEvent()
    {
        if (isOnGumEffect)
            GumSlide();
        else
        {
            animator.SetTrigger("start_sliding");
            Slide();
        }        
    }

    private void GumSlide()
    {
        rigidBody.gravityScale = +0.5f;
    }

    private void Slide()
    {        
        bodyCollider.enabled = true;
        rigidBody.velocity = Vector2.down * 3f;
        animator.SetTrigger("press_slide");
        StartCoroutine(StopSliding());
    }

    IEnumerator StopSliding()
    {
        yield return new WaitForSeconds(0.7f);
        animator.SetTrigger("no_press_slide");
        bodyCollider.enabled = false;
    }
    IEnumerator GumCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
    }
    
    public void HoldingSlideButton()
    {
        bodyCollider.enabled = true;
        rigidBody.velocity = Vector2.down * 3f;
        animator.SetTrigger("press_slide");
    }

    public void NotHoldingSlideButton()
    {
        StopSliding();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        switch(collider2D.tag)
        {
            case "Enemy":
                {
                    if (shield.activeSelf)
                        return;
                    TakeDamage();
                    break;
                }
            case "speedBoost":
                {
                    moveSpeed *= 1.6f;
                    break;
                }
            case "element":
                {
                    break;
                }
            default:
                // code block
                break;
        }      
    }

    public void TakeDamage()
    {
        animator.SetTrigger("onTrap");               
    }
}

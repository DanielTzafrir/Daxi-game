using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float moveSpeed = 5f; // Speed of player movement
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private CapsuleCollider2D bodyCollider;   

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
}

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }
    public void JumpEvent()
    {
        Jump();
    }

    
    private void Jump()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground))
        {            
            animator.SetTrigger("jump");
            rigidBody.velocity = Vector2.up * jumpSpeed;
        }
    }

    public void SlideEvent()
    {
        Debug.Log("sLIDE event");

        Slide();
    }

    private void Slide()
    {        
        animator.SetTrigger("start_sliding");
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
    /*
    public void holdingSlideButton()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, grouneLayer);

        if (isGrounded && !gum)
        {
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
            ani.ResetTrigger("start_sliding");
            ani.ResetTrigger("press_slide");
            StartCoroutine(stoptrigger());
            rb.velocity = Vector2.down * slideSpeed;
        }
    }*/
}

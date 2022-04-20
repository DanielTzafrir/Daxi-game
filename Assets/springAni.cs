using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springAni : MonoBehaviour
{
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private  LayerMask springLayer;


    private Animator ani;
    private bool isGrounded;

    void Start()
    {
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, springLayer);

        Debug.Log("out");
        if (isGrounded)
        {
            ani.SetTrigger("OnIt");
            Debug.Log("in");
        }
    }
}

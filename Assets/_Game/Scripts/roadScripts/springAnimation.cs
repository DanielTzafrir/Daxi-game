using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springAnimation : MonoBehaviour
{
    [SerializeField] private GameObject player;


    private Animator ani;
    private bool isTouchingPlayer;

    void Start()
    {
        ani = GetComponent<Animator>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !player.GetComponent<Movment>().Grounded)
        {
            ani.SetTrigger("OnIt");
        }
    }
    
}

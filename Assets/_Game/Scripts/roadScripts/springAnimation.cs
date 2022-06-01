using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springAnimation : MonoBehaviour
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform playerCheck2;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject player;


    private Animator ani;
    private bool isTouchingPlayer;

    void Start()
    {
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        isTouchingPlayer = Physics2D.OverlapCircle(playerCheck.position, 0.2f, playerLayer) || Physics2D.OverlapCircle(playerCheck2.position, 0.2f, playerLayer);

        if (isTouchingPlayer && !player.GetComponent<Movment>().Grounded)
        {
            ani.SetTrigger("OnIt");
        }
    }
}

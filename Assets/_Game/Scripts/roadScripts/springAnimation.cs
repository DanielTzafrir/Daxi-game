using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springAnimation : MonoBehaviour
{
    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform playerCheck2;
    [SerializeField] private LayerMask springLayer;


    private Animator ani;
    private bool isTouchingPlayer;

    void Start()
    {
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        isTouchingPlayer = Physics2D.OverlapCircle(playerCheck.position, 0.2f, springLayer) || Physics2D.OverlapCircle(playerCheck2.position, 0.2f, springLayer);

        if (isTouchingPlayer)
        {
            ani.SetTrigger("OnIt");
        }
    }
}

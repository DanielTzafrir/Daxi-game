using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pliersAni : MonoBehaviour
{
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ani.SetTrigger("OnPlier");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    [SerializeField] private GameObject[] powers;

    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {

            GameObject player = collision.gameObject;
            Movment playerScript = player.GetComponent<Movment>();

            if (playerScript)
            {
                
            }
        }
    }
}

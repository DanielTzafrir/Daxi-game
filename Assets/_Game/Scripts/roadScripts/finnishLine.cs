using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finnishLine : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            StartCoroutine(wait2sec());
            StartCoroutine(wait1sec());
        }
    }

    IEnumerator wait2sec()
    {
        yield return new WaitForSeconds(2);
        player.GetComponent<Animator>().SetTrigger("victory");

    }
    IEnumerator wait1sec()
    {
        yield return new WaitForSeconds(0.8f);
        player.GetComponent<Movment>().Speed = 0;
        player.GetComponent<Animator>().SetTrigger("stand");

    }
}

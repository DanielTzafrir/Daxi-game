using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardTrap : MonoBehaviour
{
    [SerializeField] private GameObject board1;
    [SerializeField] private GameObject board2;

    public void triggerBoard()
    {
        board1.GetComponent<Animator>().SetTrigger("on");
        board2.GetComponent<Animator>().SetTrigger("on");
    }
}

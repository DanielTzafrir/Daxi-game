using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonsControl : MonoBehaviour
{
    public Button worldsButton;
    public GameObject lockMask;
    public GameObject TitleImg;
    public bool lockworlds;

    private bool wasIn = false;
    void Start()
    {
        if (lockworlds)
        {
            TitleImg.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (checkFinnishWorld1() && wasIn)
        {
            lockworlds = true;
            TitleImg.gameObject.SetActive(true);
            lockMask.gameObject.SetActive(false);
            wasIn = false;
        }
    }

    public bool checkFinnishWorld1()
    {
        return true;
    } 

}

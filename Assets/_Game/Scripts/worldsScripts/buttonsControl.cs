using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonsControl : MonoBehaviour
{
    public Button[] worldsButton;
    
    private bool[] lockworlds;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private bool checkworld(int num)
    {
        return lockworlds[num];
    }
}

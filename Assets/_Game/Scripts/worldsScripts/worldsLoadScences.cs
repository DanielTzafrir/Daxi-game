using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class worldsLoadScences : MonoBehaviour
{
    public void LoadWorld1()
    {
        SceneManager.LoadScene("lvls world 1");
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("main");
    }   
}

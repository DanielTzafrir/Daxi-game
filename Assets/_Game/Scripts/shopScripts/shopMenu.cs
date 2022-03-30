using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopMenu : MonoBehaviour
{
    public void LoadPlay()
    {
        SceneManager.LoadScene("lvl 1");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("shop");
    }

    public void back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main");
    }
}

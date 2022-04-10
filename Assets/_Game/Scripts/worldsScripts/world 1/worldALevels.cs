using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class worldALevels : MonoBehaviour
{
    public void LoadWorlds()
    {
        SceneManager.LoadScene("worlds");
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene("lvl 1");
    }
    public void LoadLvl2()
    {
        //SceneManager.LoadScene("lvl 2");
        Debug.Log("1");
    }
    public void LoadLvl3()
    {
        //SceneManager.LoadScene("lvl 3");
    }
    public void LoadLvl4()
    {
        //SceneManager.LoadScene("lvl 4");
    }
    public void LoadLvl5()
    {
        //SceneManager.LoadScene("lvl 5");
    }
    public void LoadLvl6()
    {
        //SceneManager.LoadScene("lvl 6");
    }

}

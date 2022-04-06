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
        SceneManager.LoadScene("lvls world 1");
    }
}

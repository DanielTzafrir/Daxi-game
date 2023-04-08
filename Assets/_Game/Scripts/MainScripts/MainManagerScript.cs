using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManagerScript : MonoBehaviour
{
   public static MainManagerScript Instance;
   [SerializeField] private int currentLevel;

    public void SetLevel(int level)
    {
        currentLevel = level;
    }
    public int GetLevel()
    {
        return currentLevel;
    }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MissionLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI  missionText;
    [SerializeField] Image missionSprite;
    [SerializeField] TextMeshProUGUI missionCollectionCount;
    [SerializeField] Button resumeButton;
    private AsyncOperation asyncLoad;

    void Start()
    {
        LoadSceneInBackground("lvl 1");
    }

    private void LoadSceneInBackground(string sceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
    }

    public void LoadLevel()
    {
        asyncLoad.allowSceneActivation = true;
        Destroy(this);
    }
  private void Update()
    {
        Debug.Log(asyncLoad.progress);
        // Check if the scene is ready to be activated
        if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
        {
            resumeButton.interactable = true;
        }
    }
}

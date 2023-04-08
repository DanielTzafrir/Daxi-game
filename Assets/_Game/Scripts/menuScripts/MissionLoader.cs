using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MissionLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI  missionText;
    [SerializeField] Image missionSprite;
    [SerializeField] TextMeshProUGUI missionCollectionCount;
    [SerializeField] Button resumeButton;
    [SerializeField]private ConfigLevelData configLevelData;
    [SerializeField] private ConfigLevelDataArray configArray;
    private AsyncOperation asyncLoad;

    void Awake()
    {
        LoadSceneInBackground("lvl 1");
        GetMissionFromConfig();
    }

    void GetMissionFromConfig()
    {
        GetConfigLevelData();
        missionText.text = configLevelData.missionText.Replace("$",configLevelData.missionCount.ToString());
        missionSprite.sprite = Resources.Load<Sprite>("Donut13");
    }

    private void GetConfigLevelData()
    {
        
        int level = MainManagerScript.Instance.GetLevel();
        string filePath = Application.dataPath + "/Configs/levelConfig.json";
        print(filePath);
        if (File.Exists(filePath))
        {
            
            string jsonData = File.ReadAllText(filePath);
            configArray =  JsonUtility.FromJson<ConfigLevelDataArray>(jsonData);
            configLevelData = configArray.levelsArray[level-1];
        }
        else
        {
            Debug.LogError("Config file not found!");
        }
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

[System.Serializable]
public class ConfigLevelDataArray
{
    public ConfigLevelData[] levelsArray;
}

[System.Serializable]
public class ConfigLevelData
{
    public string missionText;
    public string imageName;
    public string missionCount;
}
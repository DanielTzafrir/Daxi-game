using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersButtonScript : MonoBehaviour
{    
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Image image;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject levelManager;
    [SerializeField] private Image Mask;
    [SerializeField] private float PowerDelayInSeconds = 5f;

    public void PowerWasCollected()
    {
        StartCoroutine(ChangesFillAmount(PowerDelayInSeconds,Mask));
    }
    public void PowerUsed()
    {
        if(Mask.fillAmount==0)
        {
            UpdatePlayer();
            UpdateLevelManager(image.sprite);
        }        
    }
    private void UpdateLevelManager(Sprite imageSprite)
    {
        levelManager.GetComponent<LevelScript>().powerWasUsed(imageSprite);
        //image.sprite = defaultSprite;
    }
    private void UpdatePlayer()
    {
        player.GetComponent<ButtonPower>().UsePower(image.mainTexture.name);                
    }
    private IEnumerator ChangesFillAmount(float duration,Image image)
    {    
        float startTimeOfMask = 0;
        while (startTimeOfMask < duration)
        {
            startTimeOfMask += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(1, 0, startTimeOfMask / duration);
            yield return null;
        }  
        image.fillAmount=0f;      
    }   
}

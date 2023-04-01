using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LevelScript : MonoBehaviour
{    
    [SerializeField] private List<Sprite> powersOptions;
    [SerializeField] private List<GameObject> powerButtons;
    [SerializeField] private List<Sprite> powersOptionsLeft;
    [SerializeField] private Sprite defaultSprite;
    private int buttonToUpdate = 0;

    void Start()
    {
        powersOptionsLeft =new List<Sprite>(powersOptions);
    }
    public void PowerRecieved()
    {        
        if(buttonToUpdate<powerButtons.Count)
        {
            UpdateLastButtonPosition();
        }
        
    }
    public void powerWasUsed(Sprite powerToReturnToList)
    {
        int usedPosition = GetButtonPosition(powerToReturnToList);        
        powerButtons[usedPosition].SetActive(false);

        for(int i=usedPosition; i<powerButtons.Count-1; i++)
        {
            if(powerButtons[i+1].activeSelf)
            {
                GetSpriteFromNext(i);
            }
        }
        powersOptionsLeft.Add(powerToReturnToList);
        if(powersOptionsLeft.Count == powersOptions.Count)
        {
            powerButtons[0].GetComponent<Image>().sprite = defaultSprite;
            powerButtons[0].SetActive(true);
        }
        buttonToUpdate--;
    }

    private void GetSpriteFromNext(int i)
    {
        powerButtons[i].GetComponent<Image>().sprite = powerButtons[i + 1].GetComponent<Image>().sprite;
        powerButtons[i].SetActive(true);
        powerButtons[i + 1].SetActive(false);
    }

    private void UpdateLastButtonPosition()
    {
        int chosenPower = Random.Range(0,powersOptionsLeft.Count);
        powerButtons[buttonToUpdate].SetActive(true);
        powerButtons[buttonToUpdate].GetComponent<Image>().sprite = powersOptionsLeft[chosenPower];
        powerButtons[buttonToUpdate].GetComponent<PowersButtonScript>().PowerWasCollected();
        powersOptionsLeft.RemoveAt(chosenPower); 
        buttonToUpdate++;
    }
    

    private int GetButtonPosition(Sprite usedPower)
    {
        int buttonPower = 0;
        foreach(var button in powerButtons)
        {
            if(button.GetComponent<Image>().sprite == usedPower)
                break;
            buttonPower++;
        }
        return buttonPower;
    }
}

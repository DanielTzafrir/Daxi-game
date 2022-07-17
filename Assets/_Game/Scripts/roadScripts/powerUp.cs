using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUp : MonoBehaviour 
{
    [SerializeField] private GameObject shield;
    [SerializeField] private Button powerbutton1;
    [SerializeField] private Button powerbutton2;
    [SerializeField] private Button powerbutton3;
    [SerializeField] private Sprite GumBtIm;
    [SerializeField] private Sprite ShieldBtIm;
    [SerializeField] private Sprite BoardBtIm;

    private void Update()
    {
        moveButtons();
    }

    private void moveButtons()
    {
        if (!gameObject.GetComponentInParent<BoolPowers>().Power1 && gameObject.GetComponentInParent<BoolPowers>().Power2)
        {
            //move the data in power2 to power1 and then:
            powerbutton1.image.sprite = powerbutton2.image.sprite;
            powerbutton2.gameObject.SetActive(false);
            gameObject.GetComponentInParent<BoolPowers>().Power1 = true;
            gameObject.GetComponentInParent<BoolPowers>().Power2 = false;
        }
        if (!gameObject.GetComponentInParent<BoolPowers>().Power2 && gameObject.GetComponentInParent<BoolPowers>().Power3)
        {
            //move the data in power3 to power2 and then:
            gameObject.GetComponentInParent<BoolPowers>().Power2 = true;
            gameObject.GetComponentInParent<BoolPowers>().Power3 = false;
        }
    }

    private void afterUsingPower()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.GetComponentInParent<BoolPowers>().Power1)
        {
            RandomPower();
            ActivateForPower1();
            gameObject.GetComponentInParent<BoolPowers>().Power1 = true;

        }
        else if (!gameObject.GetComponentInParent<BoolPowers>().Power2)
        {
            RandomPower();
            ActivateForPower2();
            gameObject.GetComponentInParent<BoolPowers>().Power2 = true;

        }
        else if (!gameObject.GetComponentInParent<BoolPowers>().Power3)
        {
            gameObject.GetComponentInParent<BoolPowers>().Random = TheLastPower();
            ActivateForPower3();
            gameObject.GetComponentInParent<BoolPowers>().Power3 = true;

        }
    }

    
    public void ActivateForPower1()
    {
        switch (gameObject.GetComponentInParent<BoolPowers>().Random)
        {
            case 0: // Gum
                powerbutton1.image.sprite = GumBtIm;
                break;
            case 1: // Shield
                powerbutton1.image.sprite = ShieldBtIm;
                break;
            case 2: // Board
                powerbutton1.image.sprite = BoardBtIm;
                break;
        }
        Destroy(gameObject);
    }
    public void ActivateForPower2()
    {
        powerbutton2.gameObject.SetActive(true);
        switch (gameObject.GetComponentInParent<BoolPowers>().Random)
        {
            case 0: // Gum
                powerbutton2.image.sprite = GumBtIm;
                break;
            case 1: // Shield
                powerbutton2.image.sprite = ShieldBtIm;
                break;
            case 2: // Board
                powerbutton2.image.sprite = BoardBtIm;
                break;
        }
        Destroy(gameObject);
    }

    public void ActivateForPower3()
    {
        powerbutton3.gameObject.SetActive(true);
        switch (gameObject.GetComponentInParent<BoolPowers>().Random)
        {
            case 0: // Gum
                powerbutton3.image.sprite = GumBtIm;
                break;
            case 1: // Shield
                powerbutton3.image.sprite = ShieldBtIm;
                break;
            case 2: // Board
                powerbutton3.image.sprite = BoardBtIm;
                break;
        }
        Destroy(gameObject);
    }

    public void RandomPower()
    {
        if (powerbutton1.GetComponent<Image>().sprite.name != "power")
        {
            if (powerbutton1.GetComponent<Image>().sprite.name == "Gum button")
            {
                gameObject.GetComponentInParent<BoolPowers>().Random = Random.Range(1, 3);
            }
            else if (powerbutton1.GetComponent<Image>().sprite.name == "Shield button")
            {
                while (gameObject.GetComponentInParent<BoolPowers>().Random == 1)
                {
                    gameObject.GetComponentInParent<BoolPowers>().Random = Random.Range(0, 3);
                }
            }
            else if (powerbutton1.GetComponent<Image>().sprite.name == "Board button")
            {
                gameObject.GetComponentInParent<BoolPowers>().Random = Random.Range(0, 2);
            }
        }
        else
        {
            gameObject.GetComponentInParent<BoolPowers>().Random = Random.Range(0, 3);
        }

    }

    public int TheLastPower()
    {
        if (powerbutton1.GetComponent<Image>().sprite.name == "Gum button")
        {
            if (powerbutton2.GetComponent<Image>().sprite.name == "Shield button")
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
        else if (powerbutton1.GetComponent<Image>().sprite.name == "Shield button")
        {
            if (powerbutton2.GetComponent<Image>().sprite.name == "Gum button")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            if (powerbutton2.GetComponent<Image>().sprite.name == "Gum button")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

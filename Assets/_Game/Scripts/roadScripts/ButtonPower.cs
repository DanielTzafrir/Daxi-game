using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPower : MonoBehaviour
{
    [SerializeField] private Sprite defaultPowerIm;
    [SerializeField] private Button power1;
    [SerializeField] private Button power2;
    [SerializeField] private Button power3;
    [SerializeField] private GameObject shield;

    public void usePower1()
    {
        
        if (power1.GetComponent<Image>().sprite.name != "power")
        {
            if (power1.GetComponent<Image>().sprite.name == "Gum button")
            {
                //activate animation of gum and change the rigidBuddy for 15 sec. can be controlled by the up and down buttons
                Debug.Log("gum");
            }
            else if (power1.GetComponent<Image>().sprite.name == "Shield button")
            {
                // activate the shield for 15 sec.
                shield.SetActive(true);
                StartCoroutine(waitShield());
                // the character is immune while has a shield. taken care of in the Movment class. 
            }
            else if (power1.GetComponent<Image>().sprite.name == "Board button")
            {
                //throw a board under Daxi
                Debug.Log("board");

            }

            afterPressingPower1();
        }
    }

    public void usePower2()
    {
        if (power2.GetComponent<Image>().sprite.name != "power")
        {
            if (power2.GetComponent<Image>().sprite.name == "Gum button")
            {
                //activate animation of gum and change the rigidBuddy for 15 sec. can be controlled by the up and down buttons
                Debug.Log("gum");

            }
            else if (power2.GetComponent<Image>().sprite.name == "Shield button")
            {
                // activate the shield for 15 sec.
                shield.SetActive(true);
                StartCoroutine(waitShield());
                // the character is immune while has a shield. taken care of in the Movment class.

            }
            else if (power2.GetComponent<Image>().sprite.name == "Board button")
            {
                //throw a board under Daxi
                Debug.Log("board");

            }

            afterPressingPower2();
        }
    }

    public void usePower3()
    {
        if (power3.GetComponent<Image>().sprite.name != "power")
        {
            if (power3.GetComponent<Image>().sprite.name == "Gum button")
            {
                //activate animation of gum and change the rigidBuddy for 15 sec. can be controlled by the up and down buttons
                Debug.Log("gum");

            }
            else if (power3.GetComponent<Image>().sprite.name == "Shield button")
            {
                // activate the shield for 15 sec.
                shield.SetActive(true);
                StartCoroutine(waitShield());
                // the character is immune while has a shield. taken care of in the Movment class.

            }
            else if (power3.GetComponent<Image>().sprite.name == "Board button")
            {
                //throw a board under Daxi
                Debug.Log("board");

            }

            afterPressingPower3();
        }
    }
    public void afterPressingPower1()
    {
        power1.GetComponent<Image>().sprite = defaultPowerIm;
    }

    public void afterPressingPower2()
    {
        if (power3.gameObject.activeSelf)
        {
            power2.GetComponent<Image>().sprite = power3.GetComponent<Image>().sprite;
            power3.gameObject.SetActive(false);
        }
        else
        {
            power2.gameObject.SetActive(false);
        }
    }

    public void afterPressingPower3()
    {
        power3.gameObject.SetActive(false);
    }

    IEnumerator waitShield()
    {
        yield return new WaitForSeconds(15);
        shield.SetActive(false);
    }
}

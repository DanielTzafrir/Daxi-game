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
    [SerializeField] private Image power1Mask;
    [SerializeField] private Image power2Mask;
    [SerializeField] private Image power3Mask;
    [SerializeField] private GameObject board;

    private Animator ani;
    private float startTimeOfMask1 = 0;
    private float startTimeOfMask2 = 0;
    private float startTimeOfMask3 = 0;

    private void Start()
    {
        ani = GetComponent<Animator>();

        power1Mask.enabled = false;
        power2Mask.enabled = false;
        power3Mask.enabled = false;
    }
    public void usePower1()
    {
        
        if (power1.GetComponent<Image>().sprite.name != "power")
        {

            if (power1.GetComponent<Image>().sprite.name == "Gum button")
            {
                ani.SetTrigger("gum start");
                StartCoroutine(gumOn());
                gameObject.GetComponent<Movment>().Gum = true;
                maskPower1();
            }
            else if (power1.GetComponent<Image>().sprite.name == "Shield button")
            {
                shield.SetActive(true);
                StartCoroutine(waitShield());
                maskPower1();
                // the character is immune while has a shield. taken care of in the Movment class. 
            }
            else if (power1.GetComponent<Image>().sprite.name == "Board button")
            {
                //throw a board under Daxi
                useBoard();
                Debug.Log("board");
                afterPressingPower1();
            }
        }
    }

    public void usePower2()
    {
        if (power2.GetComponent<Image>().sprite.name != "power")
        {
            if (power2.GetComponent<Image>().sprite.name == "Gum button")
            {
                //activate animation of gum. 
                ani.SetTrigger("gum start");
                StartCoroutine(gumOn());
                gameObject.GetComponent<Movment>().Gum = true;
                maskPower2();
                //change the rigidBuddy for 15 sec. can be controlled by the up and down buttons (= taken care of in the Movment class).
            }
            else if (power2.GetComponent<Image>().sprite.name == "Shield button")
            {
                // activate the shield for 15 sec.
                shield.SetActive(true);
                StartCoroutine(waitShield());
                maskPower2();
                // the character is immune while has a shield (= taken care of in the Movment class).

            }
            else if (power2.GetComponent<Image>().sprite.name == "Board button")
            {
                //throw a board under Daxi
                useBoard();
                Debug.Log("board");
                afterPressingPower2();
            }
        }
    }

    public void usePower3()
    {
        if (power3.GetComponent<Image>().sprite.name != "power")
        {
            if (power3.GetComponent<Image>().sprite.name == "Gum button")
            {
                //activate animation of gum and change the rigidBuddy for 15 sec. can be controlled by the up and down buttons
                ani.SetTrigger("gum start");
                StartCoroutine(gumOn());
                gameObject.GetComponent<Movment>().Gum = true;
                maskPower3();
            }
            else if (power3.GetComponent<Image>().sprite.name == "Shield button")
            {
                // activate the shield for 15 sec.
                shield.SetActive(true);
                StartCoroutine(waitShield());
                maskPower3();
                // the character is immune while has a shield. taken care of in the Movment class.

            }
            else if (power3.GetComponent<Image>().sprite.name == "Board button")
            {
                //throw a board under Daxi
                useBoard();
                Debug.Log("board");
                afterPressingPower3();
            }
        }
    }
    public void useBoard()
    {
        GameObject boardObj = Instantiate(board, transform);
        int LayerNameToInt = LayerMask.NameToLayer("Ground");
        boardObj.gameObject.layer = LayerNameToInt;
    }
    public void afterPressingPower1()
    {
        if (power1.GetComponent<Image>().sprite.name == "Gum button")
        {
            gameObject.GetComponent<Movment>().Gum = true;
        }

        startTimeOfMask1 = 0;
        if (power2.gameObject.activeSelf)
        {
            power1.GetComponent<Image>().sprite = power2.GetComponent<Image>().sprite;

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
        else
        {
            power1.GetComponent<Image>().sprite = defaultPowerIm;
        }
    }

    public void afterPressingPower2()
    {

        if (power2.GetComponent<Image>().sprite.name == "Gum button")
        {
            gameObject.GetComponent<Movment>().Gum = true;
        }

        startTimeOfMask2 = 0;
        if (power3.gameObject.activeSelf)
        {
            power2.GetComponent<Image>().sprite = power3.GetComponent<Image>().sprite;
            power3.gameObject.SetActive(false);
        }
        else if (power2Mask.fillAmount == 1)
        {
            power2.gameObject.SetActive(false);
        }
    }

    public void afterPressingPower3()
    {

        if (power3.GetComponent<Image>().sprite.name == "Gum button")
        {
            gameObject.GetComponent<Movment>().Gum = true;
        }
        startTimeOfMask3 = 0;
        power3.gameObject.SetActive(false);
    }

    public void maskPower1()
    {
        power1Mask.enabled = true;
        power1Mask.sprite = power1.image.sprite;
        power1Mask.fillAmount = 0f;
        StartCoroutine(ChangesFillAmount1(15));
    }
    public void maskPower2()
    {
        power2Mask.enabled = true;
        power2Mask.sprite = power2.image.sprite;
        power2Mask.fillAmount = 0f;
        StartCoroutine(ChangesFillAmount2(15));
    }public void maskPower3()
    {
        power3Mask.enabled = true;
        power3Mask.sprite = power3.image.sprite;
        power3Mask.fillAmount = 0f;
        StartCoroutine(ChangesFillAmount3(15));
    }
    IEnumerator waitShield()
    {
        yield return new WaitForSeconds(15);
        shield.SetActive(false);
        //remove the imunne
    }
    IEnumerator ChangesFillAmount1(float duration)
    {

        while (startTimeOfMask1 < duration)
        {
            startTimeOfMask1 += Time.deltaTime;
            power1Mask.fillAmount = Mathf.Lerp(0, 1, startTimeOfMask1 / duration);
            yield return null;
        }

        power1Mask.enabled = false;
        afterPressingPower1();
    }
    IEnumerator ChangesFillAmount2(float duration)
    {

        while (startTimeOfMask2 < duration && power1.image.sprite != power2Mask.sprite)
        {
            startTimeOfMask2 += Time.deltaTime;
            power2Mask.fillAmount = Mathf.Lerp(0, 1, startTimeOfMask2 / duration);
            yield return null;
        }
        if (power1.image.sprite == power2Mask.sprite)
        {

            power1Mask.enabled = true;
            power1Mask.sprite = power2Mask.sprite;
            power1Mask.fillAmount = Mathf.Lerp(power2Mask.fillAmount, 1, startTimeOfMask2 / duration);
            startTimeOfMask1 = startTimeOfMask2;
            startTimeOfMask2 = 0;
            StartCoroutine(ChangesFillAmount1(15));
        }
        power2Mask.enabled = false;
        afterPressingPower2();
    }
    IEnumerator ChangesFillAmount3(float duration)
    {
        while (startTimeOfMask3 < duration && power2.image.sprite != power3Mask.sprite)
        {
            startTimeOfMask3 += Time.deltaTime;
            power3Mask.fillAmount = Mathf.Lerp(0, 1, startTimeOfMask3 / duration);
            yield return null;
        }

        if (power2.image.sprite == power3Mask.sprite)
        {
            power2Mask.enabled = true;
            power2Mask.sprite = power3Mask.sprite;
            power2Mask.fillAmount = Mathf.Lerp(power3Mask.fillAmount, 1, startTimeOfMask3 / duration);
            startTimeOfMask2 = startTimeOfMask3;
            startTimeOfMask3 = 0;
            StartCoroutine(ChangesFillAmount2(15));
        }
        power3Mask.enabled = false;
        afterPressingPower3();
    }

    IEnumerator gumOn()
    {
        yield return new WaitForSeconds(15);
        ani.SetTrigger("finnish gum");
    }
}

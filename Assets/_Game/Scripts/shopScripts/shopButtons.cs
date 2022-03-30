using UnityEngine;

public class shopButtons : MonoBehaviour
{
    public GameObject SV_Skin;
    public GameObject SV_follower;
    public GameObject SV_life;
    public GameObject SV_power;

    public void skinOn()
    {
        SV_Skin.SetActive(true);
        SV_follower.SetActive(false);
        SV_life.SetActive(false);
        SV_power.SetActive(false);
    }
    public void followerOn()
    {
        SV_Skin.SetActive(false);
        SV_follower.SetActive(true);
        SV_life.SetActive(false);
        SV_power.SetActive(false);
    }
    public void lifeOn()
    {
        SV_Skin.SetActive(false);
        SV_follower.SetActive(false);
        SV_life.SetActive(true);
        SV_power.SetActive(false);
    }
    public void powerOn()
    {
        SV_Skin.SetActive(false);
        SV_follower.SetActive(false);
        SV_life.SetActive(false);
        SV_power.SetActive(true);
    }
}

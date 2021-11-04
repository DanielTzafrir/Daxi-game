
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimationController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.CompareTag("Player"))
        //{
        Debug.Log("Trigger!");
            myAnimationController.SetBool("OnIt", true);
        //}
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            myAnimationController.SetBool("OnIt", false);
        }
    }*/


}

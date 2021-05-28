using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLoader : MonoBehaviour
{
    public Animator camAnim;
    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camAnim.SetBool("Cutscene1", true);
            camAnim.SetBool("Cutscene2", true);
            Invoke(nameof(StopCutscene), 2f);
            //Debug.Log("XDDDD");
        }

    }
    
    void StopCutscene()
    {
        camAnim.SetBool("Cutscene1", false);
        camAnim.SetBool("Cutscene2", false);
    }
        
}


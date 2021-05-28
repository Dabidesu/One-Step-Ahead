using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevelUponDeath : MonoBehaviour
{
    public int LoadLevelusingInt;
    public string LoadLevelusingStr;

    public bool IntegerLevelLoader = false;
    public HealthBar hp;


    public bool isDead()
    {
        return true;
    }


    void Update()
    {
        if (hp.GameOver())
        {
            isDead();
            if (isDead())
            {
                LoadScene();
                //Debug.Log("It works lmao");
            }
        }

    }



    void LoadScene()
    {
        if (IntegerLevelLoader)
            SceneManager.LoadScene(LoadLevelusingInt);
        else
            SceneManager.LoadScene(LoadLevelusingStr);
    }
}

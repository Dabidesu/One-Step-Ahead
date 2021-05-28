using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reloader : MonoBehaviour
{
    public int LoadLevelusingInt;
    public string LoadLevelusingStr;

    public bool IntegerLevelLoader = false;
    public bool isSpacePressed;
    public bool isEnterPressed;
    public bool isEPressed;

    public NewPlayerController pub;


    void Update()
    {
        if (pub.speedo != 0 || isSpacePressed || isEnterPressed || isEPressed)
        {
            LoadScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        isSpacePressed = Input.GetKeyDown(KeyCode.Space);
        isEnterPressed = Input.GetKeyDown(KeyCode.Return);
        isEPressed = Input.GetKeyDown(KeyCode.E);
        if (pub.speedo != 0 || isSpacePressed || isEnterPressed || isEPressed)
        {
            LoadScene();
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

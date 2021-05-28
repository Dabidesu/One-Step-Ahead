using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int i;
    public float typingSpeed;

    public GameObject Continue;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if (textDisplay.text == sentences[i])
        {
            Continue.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        //yield return new WaitForSeconds(2f);
        foreach (char letter in sentences[i].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        Continue.SetActive(false);

        if(i < sentences.Length - 1)
        {
            i++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            Continue.SetActive(false);
        }
    }
}

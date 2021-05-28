using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    public bool isDead;
    public bool condition = false;

    //100 health => 1 fill amount
    //45 health => 0.45 fill amount

    public void LoseHealth(int value)
    {
        //If no lives remaining do nothing
        if (health == 0f)
            return;

        //Reduce the health
        health -= value;

        //Refresh the UI fillBar
        fillBar.fillAmount = health / 100;

        //Check if your health is zero or less => Dead
        if (health <= 0)
        {
            //Debug.Log("YOU DIED");
            GameOver();
        }

    }

    public bool GameOver()
    {
        if(health <= 0)
        {
        return true;
        }
        return false;
    }

    private void Update()
    {
        
    }
}

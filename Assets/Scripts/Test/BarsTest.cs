using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (CinematicBars.Instance != null)
                CinematicBars.Instance.ShowBars();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(CinematicBars.Instance != null)
               CinematicBars.Instance.HideBars();
        }
    }
}

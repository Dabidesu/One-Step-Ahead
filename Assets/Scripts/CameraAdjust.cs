using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    private float camSize = 30f;

    void Awake()
    {
        Camera.main.orthographicSize = camSize;
    }
}

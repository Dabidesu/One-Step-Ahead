using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpened = false;

    [SerializeField] int xValue = 4;
    [SerializeField] int yValue = 0;
    [SerializeField] int zValue = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(xValue, yValue, zValue);
        }
    }
}
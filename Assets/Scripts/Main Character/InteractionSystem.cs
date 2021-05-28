using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    // Update is called once per frame
    [Header("Detection Parameters")]

    //DetectionPoint
    public Transform detectionPoint;

    //Detection Radius
    public const float detectionRadius = 0.2f;

    //Detection Layer
    public LayerMask detectionLayer;

    //CACHED TRIGGER OBJECT
    public GameObject detectedObject;
    [Header("Examine Fields")]

    //Examine window object
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public Font fontxd;
    public bool isExamining = false;
    [Header("Others")]
    

    //List of picked items
    public List<GameObject> pickedItems = new List<GameObject>();

    void Start()
    {
        //examineText = GetComponent<Text>();
    }
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }
    bool InteractInput()
    {
       return Input.GetKeyDown(KeyCode.E);
    }
    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }

    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            //Hide the Examine Window
            examineWindow.SetActive(false);
            //enable the boolean
            isExamining = false;
        }
        else
        {
            //Show the item's image in the middle
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;

            //write description text underneath the image
            //examineText = new Text();
            examineText.font = fontxd;
            examineText.text = item.descriptionText;
            

            //Display an Examine Window
            examineWindow.SetActive(true);

            //enable the boolean
            isExamining = true;
        }
    }
}

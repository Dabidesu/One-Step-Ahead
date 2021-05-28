using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Item : MonoBehaviour
{
    public enum  InteractionType {NONE, PickUp, Examine}
    public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    public Sprite image;
    //Interaction Type

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 8;
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                
                //Add object to PickedUpItems
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);

                //Then Delete Object
                gameObject.SetActive(false);
                break;


               

            case InteractionType.Examine:
                //Call the Examine item in the interaction system
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;

            default:
                Debug.Log("NULL ITEM");
                break;

        }
    }
}

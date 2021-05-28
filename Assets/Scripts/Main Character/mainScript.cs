using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{

    //public fields
    public float speed;
    bool facingRight = true;
    //Private Fields
    Rigidbody2D rb;
    float horizontalValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanMove() == false)
        {
            horizontalValue = 0f;
            return;
        }
        else if (CanMove() == true)
        {
            horizontalValue = Input.GetAxisRaw("Horizontal");
        }
        
    }

    bool CanMove()
    {
        
        bool can = true;
        if (FindObjectOfType<InteractionSystem>().isExamining)
        can = false;
        
        return can;
    }

    void FixedUpdate()
    {
        Move(horizontalValue);
    }

    void Move(float dir)
    {
        float xVal = dir * speed;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        //Store current scale value
        Vector3 currentScale = transform.localScale;

        //flipping left
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }

        //flipping right
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }


    }
}


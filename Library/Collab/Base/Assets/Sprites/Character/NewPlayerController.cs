using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float moveX;
    public float moveY;
    public Rigidbody2D rb;

    
    public Animator animatorzxc;

    private Vector2 moveDirection;
    private bool facingRight = false;

    void Start()
    {
        animatorzxc = GetComponent<Animator> ();
    }

    void Update()
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        Move();
        //animatorzxc.SetFloat("Horizontal", moveX);

        if (moveX < 0 && !facingRight)
            reverseImage();
        else if (moveX > 0 && facingRight)
            reverseImage();
    }

    void ProcessInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        //Debug.Log(moveX);
        //Debug.Log(moveY);

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }

    void reverseImage()
    {
        facingRight = !facingRight;
        Vector2 scale = GetComponent<Rigidbody2D>().transform.localScale;
        scale.x *= -1;
        rb.transform.localScale = scale;
    }
}

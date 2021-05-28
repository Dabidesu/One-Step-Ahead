using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float speed;
    public float moveX;
    public float moveY;
    public float speedo;
    public Rigidbody2D rb;


    public Animator animatorzxc;
    public InteractionSystem inter;

    private Vector2 moveDirection;
    private bool facingRight = false;
    private bool hasExamined = false;

    void Start()
    {


    }

    void Update()
    {
        ProcessInput();
        InteractAnim();
        animatorzxc.SetFloat("Horizontal", moveX);
        animatorzxc.SetFloat("Vertical", moveY);
        //Debug.Log("XD");
    }

    void FixedUpdate()
    {
        Move();

        if (moveX < 0 && !facingRight)
            reverseImage();
        else if (moveX > 0 && facingRight)
            reverseImage();
    }

    void ProcessInput()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        speedo = moveX + moveY;
        //Debug.Log(moveX);
        //Debug.Log(moveY);

        speed = moveX + moveY;
        if (speed != 0 || 
            Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.S) || 
            Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.S))
        {
            animatorzxc.SetBool("isWalking", true);

        }
        else if (speed == 0)
            animatorzxc.SetBool("isWalking", false);
        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        
    }

    void InteractAnim()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hasExamined = true;
            movementSpeed = 0;
            animatorzxc.SetBool("isExamining", true);
            
        }
        else if(movementSpeed == 0 && speed != 0)
        {
            animatorzxc.SetBool("isExamining", false);
            movementSpeed = 2;
        }
    }
    void reverseImage()
    {
        facingRight = !facingRight;
        Vector2 scale = GetComponent<Rigidbody2D>().transform.localScale;
        scale.x *= -1;
        rb.transform.localScale = scale;
    }
}

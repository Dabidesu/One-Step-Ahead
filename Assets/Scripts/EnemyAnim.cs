using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public float movementSpeed;
    public float speed;
    public float moveX;
    public float moveY;
    public Rigidbody2D rb;


    public Animator eneanim;

    private Vector2 moveDirection;
    private bool inCombat = true;
    private bool isPunching = false;

    void Start()
    {


    }

    void Update()
    {
        CombatMode();
        eneanim.SetBool("inCombat", true);
        eneanim.SetFloat("Horizontal", moveX);
        eneanim.SetFloat("Vertical", moveY);
    }


    void CombatMode()
    {
  
            
    }


 
}

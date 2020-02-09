using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{
    public float movementSpeed = 7;
    Animator playerAnimator;
    Rigidbody2D rb2D;
    Vector2 movement = new Vector2();

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MoveCharacter();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnimator.SetBool("walkingwest", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAnimator.SetBool("walkingeast", true);
        }
        else
        {
            playerAnimator.SetBool("walkingwest", false);
            playerAnimator.SetBool("walkingeast", false);
        }
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }
}

    
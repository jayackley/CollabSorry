﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {


    public float movementSpeed = 3.0f;
    public bool footSteps;
    AudioSource sound;
    Vector2 movement = new Vector2();

    Animator animator;

    Rigidbody2D rb2D;


	private void Start () {

        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();
    }
	

	private void Update () {

        UpdateState();
	}

    void FixedUpdate()
    {

        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        rb2D.velocity = movement * movementSpeed;
    }

    void UpdateState()
    {
        if (Mathf.Approximately(movement.x,0) && Mathf.Approximately(movement.y,0))
        {
            animator.SetBool("isWalking", false);
            footSteps = false;
        }
        else
        {
            animator.SetBool("isWalking", true);
            footSteps = true;

        }

        animator.SetFloat("xDir", movement.x);
        animator.SetFloat("yDir", movement.y);

        if (footSteps == true && sound.isPlaying == false)
        {
            sound.loop = true;
            sound.Play(); 
        }
        else
        {
            sound.loop = false;
        }
    }
}




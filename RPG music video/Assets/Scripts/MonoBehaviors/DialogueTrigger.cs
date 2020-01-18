﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueManager;
    BoxCollider2D boxCollider2D;
    SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        renderer.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dialogue Trigger");
            dialogueManager.GetComponent<Dialogue>().NextSentence();
            boxCollider2D.enabled = false;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public int index;
    public float typingSpeed;
    public Animator textDisplayAnim;

    private void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type(){

        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        textDisplayAnim.SetTrigger("Change");

        if(index < sentences.Length -1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else{
            textDisplay.text = "";
        } 

    }

}

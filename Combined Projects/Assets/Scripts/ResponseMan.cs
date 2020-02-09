using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseMan : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public GameObject optionManager;
    public GameObject dialogueHolder;



    void Update()
    {
        textDisplay.text = sentences[optionManager.GetComponent<OptionManager>().sentenceIndex];
    }
 
}
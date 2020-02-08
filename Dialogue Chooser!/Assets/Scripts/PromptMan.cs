using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PromptMan : MonoBehaviour
{
    public GameObject optionManager;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    public bool isTyping;
    public GameObject spacePanel;



    IEnumerator Type()
    {
        foreach (char letter in sentences[optionManager.GetComponent<OptionManager>().sentenceIndex].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[optionManager.GetComponent<OptionManager>().sentenceIndex]){
            isTyping = false;
            spacePanel.SetActive(false);
        }
        else
        {
            isTyping = true;
        }
    }
}
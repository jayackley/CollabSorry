using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionManager : MonoBehaviour
{

    public int currentSelect;
    public GameObject optionOne;
    public GameObject optionTwo;
    public GameObject optionThree;
    public GameObject promptText;
    public GameObject scoreObject;
    public GameObject spacePanel;
    public int sentenceIndex;
    public GameObject promptPanel;

    void Start()
    {
        currentSelect = 1;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);
        spacePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (promptPanel.GetComponent<PromptMan>().isTyping == true)
        {
            optionOne.SetActive(false);
            optionTwo.SetActive(false);
            optionThree.SetActive(false);
        }

        else if (currentSelect == 1 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            optionOne.SetActive(true);
            optionTwo.SetActive(true);
            optionThree.SetActive(true);
            optionOne.GetComponent<Image>().color = UnityEngine.Color.red;
            optionTwo.GetComponent<Image>().color = UnityEngine.Color.blue;
            optionThree.GetComponent<Image>().color = UnityEngine.Color.blue;
        }
        else if (currentSelect == 2 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            optionOne.SetActive(true);
            optionTwo.SetActive(true);
            optionThree.SetActive(true);
            optionOne.GetComponent<Image>().color = UnityEngine.Color.blue;
            optionTwo.GetComponent<Image>().color = UnityEngine.Color.red;
            optionThree.GetComponent<Image>().color = UnityEngine.Color.blue;
        }
        else if (currentSelect == 3 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            optionOne.SetActive(true);
            optionTwo.SetActive(true);
            optionThree.SetActive(true);
            optionOne.GetComponent<Image>().color = UnityEngine.Color.blue;
            optionTwo.GetComponent<Image>().color = UnityEngine.Color.blue;
            optionThree.GetComponent<Image>().color = UnityEngine.Color.red;
        }
        else if (currentSelect == 0)
        {
            optionOne.SetActive(false);
            optionTwo.SetActive(false);
            optionThree.SetActive(false);
        }
    }
    private void OnGUI()
    {
        //Moving Between Options

        if (Event.current.Equals(Event.KeyboardEvent("down")) && currentSelect == 1)
        {
            currentSelect = 2;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("down")) && currentSelect == 2)
        {
            currentSelect = 3;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("down")) && currentSelect == 3)
        {
            currentSelect = 1;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("up")) && currentSelect == 1)
        {
            currentSelect = 3;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("up")) && currentSelect == 3)
        {
            currentSelect = 2;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("up")) && currentSelect == 2)
        {
            currentSelect = 1;
        }

        //Choosing an Option
        //&& Registering Score

        else if (Event.current.Equals(Event.KeyboardEvent("space")) && currentSelect == 1 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            promptText.GetComponent<TextMeshProUGUI>().text = "You Added Ten!";
            scoreObject.GetComponent<ScoreManager>().score += 10;
            spacePanel.SetActive(true);
            currentSelect = 0;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("space")) && currentSelect == 2 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            promptText.GetComponent<TextMeshProUGUI>().text = "You Subtracted Five!";
            scoreObject.GetComponent<ScoreManager>().score -= 5;
            spacePanel.SetActive(true);
            currentSelect = 0;
        }
        else if (Event.current.Equals(Event.KeyboardEvent("space")) && currentSelect == 3 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            promptText.GetComponent<TextMeshProUGUI>().text = "You Added One!";
            scoreObject.GetComponent<ScoreManager>().score += 1;
            spacePanel.SetActive(true);
            currentSelect = 0;
        }

        //in between choosing options 

        else if (Event.current.Equals(Event.KeyboardEvent("space")) && currentSelect == 0)
        {
            currentSelect = 1;
            sentenceIndex += 1;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            spacePanel.SetActive(false);

        }


    }
}
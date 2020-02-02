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
    public GameObject dialogueHolder;
    public GameObject playerObject;
    public GameObject gremlinVoice;
    public GameObject palVoice;

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
        if (promptPanel.GetComponent<PromptMan>().isTyping == true && playerObject.GetComponent<InteractionManager>().whosTalking == "Pal")
        {
            optionOne.SetActive(false);
            optionTwo.SetActive(false);
            optionThree.SetActive(false);
            palVoice.GetComponent<AudioSource>().volume = 100;
        }

        else if (promptPanel.GetComponent<PromptMan>().isTyping == true && playerObject.GetComponent<InteractionManager>().whosTalking == "Demon")
        {
            optionOne.SetActive(false);
            optionTwo.SetActive(false);
            optionThree.SetActive(false);
            gremlinVoice.GetComponent<AudioSource>().volume = 100;
        }

        else if (sentenceIndex == 4 || sentenceIndex == 5 || sentenceIndex == 6 || sentenceIndex == 7 || sentenceIndex == 8 || sentenceIndex == 9 || sentenceIndex == 10 || sentenceIndex == 11 || sentenceIndex == 12 || sentenceIndex == 17 || sentenceIndex == 18 ||  sentenceIndex == 19 || sentenceIndex == 20 || sentenceIndex == 21 || sentenceIndex == 22 || sentenceIndex == 23 || sentenceIndex == 24 || sentenceIndex == 25)
        {
            optionOne.SetActive(false);
            optionTwo.SetActive(false);
            optionThree.SetActive(false);
            spacePanel.SetActive(true);
            palVoice.GetComponent<AudioSource>().volume = 0;
            gremlinVoice.GetComponent<AudioSource>().volume = 0;
        }

        else if (currentSelect == 1 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            optionOne.SetActive(true);
            optionTwo.SetActive(true);
            optionThree.SetActive(true);
            palVoice.GetComponent<AudioSource>().volume = 0;
            gremlinVoice.GetComponent<AudioSource>().volume = 0;
            optionOne.GetComponent<Image>().color = UnityEngine.Color.red;
            optionTwo.GetComponent<Image>().color = UnityEngine.Color.blue;
            optionThree.GetComponent<Image>().color = UnityEngine.Color.blue;
        }
        else if (currentSelect == 2 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            optionOne.SetActive(true);
            optionTwo.SetActive(true);
            optionThree.SetActive(true);
            palVoice.GetComponent<AudioSource>().volume = 0;
            gremlinVoice.GetComponent<AudioSource>().volume = 0;
            optionOne.GetComponent<Image>().color = UnityEngine.Color.blue;
            optionTwo.GetComponent<Image>().color = UnityEngine.Color.red;
            optionThree.GetComponent<Image>().color = UnityEngine.Color.blue;
        }
        else if (currentSelect == 3 && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            optionOne.SetActive(true);
            optionTwo.SetActive(true);
            optionThree.SetActive(true);
            palVoice.GetComponent<AudioSource>().volume = 0;
            gremlinVoice.GetComponent<AudioSource>().volume = 0;
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

        else if (sentenceIndex == 0 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 1;
            scoreObject.GetComponent<ScoreManager>().score += 10;

            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 0 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 2;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 0 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 3;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 1 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 4;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 1 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 5;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 1 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 6;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 2 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 7;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 2 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 8;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 2 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 9;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 3 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 10;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 3 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 11;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 3 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 12;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
                else if (sentenceIndex == 0 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 1;
            scoreObject.GetComponent<ScoreManager>().score += 10;

            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 0 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 2;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 0 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 3;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 1 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 4;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 1 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 5;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 1 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 6;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 2 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 7;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 2 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 8;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 2 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 9;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 3 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 10;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 3 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 11;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 3 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 12;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }

        //Apple Pal Dialogue Options

        else if (sentenceIndex == 13 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 14;
            scoreObject.GetComponent<ScoreManager>().score += 10;

            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 13 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 15;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 13 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 16;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 1;

        }
        else if (sentenceIndex == 14 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 17;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 14 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 18;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 14 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 19;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 15 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 20;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 15 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 21;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 15 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 22;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 16 && currentSelect == 1 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 23;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 16 && currentSelect == 2 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 24;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;

        }
        else if (sentenceIndex == 16 && currentSelect == 3 && Event.current.Equals(Event.KeyboardEvent("space")) && promptPanel.GetComponent<PromptMan>().isTyping == false)
        {
            sentenceIndex = 25;
            scoreObject.GetComponent<ScoreManager>().score += 10;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            currentSelect = 0;
        }

        //in between choosing options 

        else if (Event.current.Equals(Event.KeyboardEvent("space")) && currentSelect == 0)
        {
            playerObject.GetComponent<InteractionManager>().whosTalking = "";
            currentSelect = 1;
            playerObject.GetComponent<MovementManager>().enabled = true;
            spacePanel.SetActive(false);
            dialogueHolder.GetComponent<Canvas>().enabled = false;
        }
    }
}
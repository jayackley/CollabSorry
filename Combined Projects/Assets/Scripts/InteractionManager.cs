using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

    public GameObject dialogueHolder;
    public GameObject optionManager;
    public GameObject promptPanel;
    public GameObject promptText;
    public GameObject playerObject;
    public GameObject spacePanel;
    public string whosTalking;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D && collision.gameObject.tag == "LeftBrother")
        {
            dialogueHolder.GetComponent<Canvas>().enabled = true;
            optionManager.GetComponent<OptionManager>().sentenceIndex = 0;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            promptText.GetComponent<TextMeshProUGUI>().color = new Color32(200, 200, 255, 255);
            playerObject.GetComponent<MovementManager>().enabled = false;
            playerObject.GetComponent<Animator>().SetBool("walkingwest", false);
            playerObject.GetComponent<Animator>().SetBool("walkingeast", false);
            whosTalking = "Demon";
            spacePanel.SetActive(false);
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        else if (collision is CircleCollider2D && collision.gameObject.tag == "RightBrother")
        {
            dialogueHolder.GetComponent<Canvas>().enabled = true; 
            optionManager.GetComponent<OptionManager>().sentenceIndex = 13;
            promptPanel.GetComponent<PromptMan>().NextSentence();
            promptText.GetComponent<TextMeshProUGUI>().color = new Color32(255,200,200,255);
            playerObject.GetComponent<MovementManager>().enabled = false;
            playerObject.GetComponent<Animator>().SetBool("walkingwest", false);
            playerObject.GetComponent<Animator>().SetBool("walkingeast", false);
            whosTalking = "Pal";
            spacePanel.SetActive(false);
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }


    }
}

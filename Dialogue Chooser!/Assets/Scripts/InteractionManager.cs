using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour {

    public GameObject dialogueHolder;
    public GameObject optionManager;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CircleCollider2D && collision.gameObject.tag == "RightBrother")
        {
            dialogueHolder.SetActive(true);
            optionManager.GetComponent<OptionManager>().sentenceIndex = 8;
        }
        else if (collision is CircleCollider2D && collision.gameObject.tag == "LeftBrother")
        {
            dialogueHolder.SetActive(true);
            optionManager.GetComponent<OptionManager>().sentenceIndex = 4;
        }

    }
}

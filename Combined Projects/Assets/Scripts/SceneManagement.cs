using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public GameObject dialogueManager;
    public GameObject playerObject;
    public bool playerDead;

    void Update ()
    {

        if (dialogueManager.GetComponent<Dialogue>().index == 12)
        {
            playerObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            playerObject.GetComponent<MovementController>().enabled = false;
            playerObject.GetComponent<Animator>().SetBool("isWalking", false);
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                enemy.SetActive(false);
            }
            StartCoroutine(Wait());
        }

        else if (dialogueManager.GetComponent<Dialogue>().index == 13)
        {
            SceneManager.LoadScene("DialogueChooser");
        }

        else if (playerDead == true)
        {
            StartCoroutine(Wait());
        }

	}

    public IEnumerator Wait()
    {   
        yield return new WaitForSeconds(5);
        dialogueManager.GetComponent<Dialogue>().index = 13;
    }
}

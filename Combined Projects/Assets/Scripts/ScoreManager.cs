using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    public int score;
    public GameObject scoreText;

	
	void Start () {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score:";
	}
	
	// Update is called once per frame
	void Update () 
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score;	
	}
}

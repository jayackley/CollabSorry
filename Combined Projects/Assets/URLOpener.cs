using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class URLOpener : MonoBehaviour {

    public string url;

    public void Open()
    {
        Application.OpenURL(url);
    }

    public void StartOver()
    {
        SceneManager.LoadScene("Walkaround");
    }

    public void DialogueRepeater()
    {
        SceneManager.LoadScene("DialogueChooser");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

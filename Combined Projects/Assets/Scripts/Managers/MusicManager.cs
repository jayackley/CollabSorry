using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {


    public GameObject dialogueManager;
    GameObject kick;
    GameObject bass;
    GameObject keys;
    GameObject lead;
    public float maxVolume;
    public float fadeInSpeed;
    public float startingVolume;

	// Use this for initialization
	void Start () 
    {
        kick = GameObject.Find("Kick");
        bass = GameObject.Find("Bass");
        keys = GameObject.Find("Keys");
        lead = GameObject.Find("Lead");

        kick.GetComponent<AudioSource>().volume = startingVolume;
        bass.GetComponent<AudioSource>().volume = startingVolume;
        keys.GetComponent<AudioSource>().volume = startingVolume;
        lead.GetComponent<AudioSource>().volume = startingVolume;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (dialogueManager.GetComponent<Dialogue>().index == 1)
        {
            if (kick.GetComponent<AudioSource>().volume < maxVolume) 
            {
                kick.GetComponent<AudioSource>().volume += fadeInSpeed * Time.deltaTime; 
            }
        }

        if (dialogueManager.GetComponent<Dialogue>().index == 2)
        {
            if (bass.GetComponent<AudioSource>().volume < maxVolume)
            {
                bass.GetComponent<AudioSource>().volume += fadeInSpeed * Time.deltaTime;
            }
        }

        if (dialogueManager.GetComponent<Dialogue>().index == 3)
        {
            if (keys.GetComponent<AudioSource>().volume < maxVolume)
            {
                keys.GetComponent<AudioSource>().volume += fadeInSpeed * Time.deltaTime;
            }
        }

        if (dialogueManager.GetComponent<Dialogue>().index == 4)
        {
            if (lead.GetComponent<AudioSource>().volume < maxVolume)
            {
                lead.GetComponent<AudioSource>().volume += fadeInSpeed * Time.deltaTime;
            }
        }// when dialogue index is added to, change the volume (gradually) of the different sub-object audios
    }
}

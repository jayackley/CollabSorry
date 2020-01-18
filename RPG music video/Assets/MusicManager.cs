using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {


    AudioSource music;

	// Use this for initialization
	void Start () 
    {
        music = GetComponent<AudioSource>();
        music.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
        // when dialogue index is added to, change the volume (gradually) of the different sub-object audios
	}
}

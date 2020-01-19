using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip gremlinDie;
    AudioSource sound;
    float hitPoints;


    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    public void GremlinDie()
    {
        sound.PlayOneShot(gremlinDie);
    }

	
}

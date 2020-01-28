using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip gremlinDie;
    public AudioClip gremlinHit;
    public AudioClip breakableBreak;
    AudioSource sound;
    float hitPoints;


    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    public void GremlinHit()
    {
        sound.PlayOneShot(gremlinHit);
    }


    public void GremlinDie()
    {
        sound.PlayOneShot(gremlinDie);
    }

    public void Break()
    {
        sound.PlayOneShot(breakableBreak);
    }
	
}

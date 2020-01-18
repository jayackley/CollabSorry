using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip gremlinDie;
    AudioSource sound;
    GameObject enemy;
    float hitPoints;


    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        hitPoints = GetComponent<Enemy>().hitPoints;
        enemy = GameObject.Find("EnemyObject");

    }
    // Update is called once per frame
    void Update () {
        if(enemy.GetComponent<Enemy>().hitPoints <= float.Epsilon)
        {
            sound.PlayOneShot(gremlinDie);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour {

    public Sprite notBroke;
    public Sprite broke;
    SpriteRenderer rend;
    GameObject soundManager;

	// Use this for initialization
	void Start () 
    {
        soundManager = GameObject.Find("SoundManager");
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = notBroke;
    }

    public void Break()
    {
        rend.sprite = broke;
        soundManager.GetComponent<SoundManager>().Break();
    }
}

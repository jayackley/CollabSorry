using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    GameObject applePal;
    public bool turnedOn;

    public float repeatInterval;

    // Use this for initialization
    public void Start()
    {
        applePal = GameObject.Find("ApplePal");
        turnedOn = false;

    }

    public void Update()
    {

        if (applePal.GetComponent<ApplePal>().hitPoints <= float.Epsilon && turnedOn == false)
        {
            repeatInterval = 5.0f;
        }
        if (repeatInterval > 0 && turnedOn == false)
        {
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
            turnedOn = true;
        }

    }

    public GameObject SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}
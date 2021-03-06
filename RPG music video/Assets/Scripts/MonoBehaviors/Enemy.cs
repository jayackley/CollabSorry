﻿using UnityEngine;
using System.Collections;

public class Enemy : Character
{
    public GameObject deathSpawn;
    GameObject soundManager;
    public int damageStrength;
    Coroutine damageCoroutine;
    public float hitPoints;
    public float Volume;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager");
    }

    private void OnEnable()
    {
        ResetCharacter();
    }

    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            soundManager.GetComponent<SoundManager>().GremlinHit();
            StartCoroutine(FlickerCharacter());
            hitPoints = hitPoints - damage;
            if (hitPoints <= float.Epsilon)
            {
                soundManager.GetComponent<SoundManager>().GremlinDie();
                KillCharacter();
                Instantiate(deathSpawn, transform.position, Quaternion.identity);
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }

            else
            {
                break;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}


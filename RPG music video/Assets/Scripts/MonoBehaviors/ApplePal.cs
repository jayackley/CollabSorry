﻿using UnityEngine;
using System.Collections;

public class ApplePal : Character
{
    public Animator animator;
    public int damageStrength;
    Coroutine damageCoroutine;
    public float hitPoints;
    AudioSource sound;
    public AudioClip hitSound;
    public AudioClip gremlinDie;
    public float Volume;

    private void OnEnable()
    {
        sound = GetComponent<AudioSource>();
        ResetCharacter();
        animator = GetComponent<Animator>();
    }

    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            sound.PlayOneShot(hitSound, Volume);
            StartCoroutine(FlickerCharacter());
            hitPoints = hitPoints - damage;
            if (hitPoints <= float.Epsilon)
            {
                animator.SetBool("isBleeding", true);
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
}


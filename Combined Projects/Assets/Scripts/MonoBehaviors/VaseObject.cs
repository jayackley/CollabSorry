using UnityEngine;
using System.Collections;

public class VaseObject : Character
{
    public Animator animator;
    Coroutine damageCoroutine;
    public float hitPoints;
    AudioSource sound;
    public AudioClip hitSound;
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
                animator.SetBool("isBroke", true);
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


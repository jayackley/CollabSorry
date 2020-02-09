using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject dialogueManager;
    AudioSource sound;
    public int damageInflicted;
    public AudioClip swordToss;


    private void Start()
    {
        sound = GetComponent<AudioSource>();
        dialogueManager = GameObject.Find("DialogueManager");
    }

    private void OnBecameVisible()
    {
        sound.PlayOneShot(swordToss, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D && collision.gameObject.tag == "ApplePal" && collision.gameObject.GetComponent<ApplePal>().lostArm == false)
        {
            ApplePal applePal = collision.gameObject.GetComponent<ApplePal>();
            StartCoroutine(applePal.DamageCharacter(damageInflicted, 1.0f));
            dialogueManager.GetComponent<Dialogue>().NextSentence();
            gameObject.SetActive(false);
        }

        if (collision is BoxCollider2D && collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.DamageCharacter(damageInflicted, 1.0f));

            gameObject.SetActive(false);
        }

        if (collision is BoxCollider2D && collision.gameObject.tag == "Breakable")
        {
            Breakables breakables = collision.gameObject.GetComponent<Breakables>();
            breakables.Break();
            breakables.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.SetActive(false);
        }



    }
}
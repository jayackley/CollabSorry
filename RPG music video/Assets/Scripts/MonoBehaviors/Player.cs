using UnityEngine;
using System.Collections;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    HealthBar healthBar;
    public GameObject dialogueManager;
    public Inventory inventoryPrefab;
    Inventory inventory;
    public HitPoints hitPoints;
    AudioSource sound;
    public AudioClip itemGrab;
    public AudioClip gotHit;


    private void OnEnable()
    {
        sound = GetComponent<AudioSource>();
        ResetCharacter();
        dialogueManager = GameObject.Find("DialogueManager");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                bool shouldDisappear = false;
                switch (hitObject.itemType)
                {

                    case Item.ItemType.COIN:
                        dialogueManager.GetComponent<Dialogue>().NextSentence();
                        shouldDisappear = inventory.AddItem(hitObject);
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.SWORD:
                        dialogueManager.GetComponent<Dialogue>().NextSentence();
                        shouldDisappear = inventory.AddItem(hitObject);
                        shouldDisappear = true;
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }

                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                    sound.PlayOneShot(itemGrab,1);

                }
            }
        }
    }
    public bool AdjustHitPoints(int amount)
    {
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Adjusted Hit Points by: " + amount + ". New value: " + hitPoints.value);
            return true;
        }
        print("didn't adjust hitpoints");
        return false;
    }
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            StartCoroutine(FlickerCharacter());
            hitPoints.value = hitPoints.value - damage;
            sound.PlayOneShot(gotHit, 1);

            if (hitPoints.value <= float.Epsilon)
            {
                KillCharacter();
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

    public override void KillCharacter()
    {
        base.KillCharacter();
        Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
    }

    public override void ResetCharacter()
    {
        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
        hitPoints.value = startingHitPoints;
    }
}


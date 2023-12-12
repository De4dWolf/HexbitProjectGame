using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFire : Fire
{
    private int saveAtWhichCheckpoint = -2; // the default value is -2 because -1 is the default value of PlayerPrefs Checkpoint and 0 is the lowest value of cheekpoint
    private float timeSpentTillCheckpoint;
    private float checkpointTimeRecord = 0;
    private float timeSpentTillPicked;
    private float PickedTimeRecord = 0;
    public AudioSource audiokey;
    protected void LateUpdate()
    {
        timeSpentTillCheckpoint += Time.time;
            timeSpentTillPicked += Time.time;

        if (GameManager.instance.saving)
        {
            saveAtWhichCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
            checkpointTimeRecord = timeSpentTillCheckpoint;
        }

        if (GameManager.instance.reset && IsCollected)
        {
            ResetFire();
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            PickedTimeRecord = timeSpentTillPicked;
            IsCollected = true;
            player.BlueFire += 1;
            audiokey.Play();
            /*GetComponent<Animator>().SetTrigger("Picked");*/ // Destroy animation 
        }
    }

    void ResetFire()
    {
        if (saveAtWhichCheckpoint != PlayerPrefs.GetInt("CurrentCheckpoint") || PickedTimeRecord > checkpointTimeRecord)
        {
            IsCollected = false;
            IsReset = true;
            player.BlueFire -= 1;
            GetComponent<CircleCollider2D>().enabled = true;
            RevertChanges();
        }

    }
}



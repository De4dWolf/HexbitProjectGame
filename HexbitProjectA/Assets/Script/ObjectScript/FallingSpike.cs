using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    public float distance;
    bool isFalling = false;
    Vector3 initialPosition;
    private int saveAtWhichCheckpoint = -2; // the default value is -2 because -1 is the default value of PlayerPrefs Checkpoint and 0 is the lowest value of cheekpoint
    private float timeSpentTillCheckpoint;
    private float checkpointTimeRecord = 0;
    private float timeSpentTillPicked;
    private float PickedTimeRecord = 0;

    private void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down,distance);

            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);

            if(hit.transform != null)
            {
                if (hit.transform.tag == "Player")
                {
                    PickedTimeRecord = timeSpentTillPicked;
                    rb.gravityScale = 5;
                    isFalling = true;
                }
            }
        }
    }

    private void LateUpdate()
    {
        timeSpentTillCheckpoint += Time.time;
        timeSpentTillPicked += Time.time;

        if (GameManager.instance.saving)
        {
            saveAtWhichCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
            checkpointTimeRecord = timeSpentTillCheckpoint;
        }

        if (GameManager.instance.reset )
        {
            ResetSpike();
        }
    }

    void ResetSpike()
    {
        if (saveAtWhichCheckpoint != PlayerPrefs.GetInt("CurrentCheckpoint") || PickedTimeRecord > checkpointTimeRecord)
        {
            Physics2D.queriesStartInColliders = true;
            transform.position = initialPosition;
            isFalling = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            rb.gravityScale = 0;
            boxCollider2D.enabled = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    public Transform boxHolder;
    private Rigidbody2D rb;
    public AudioSource dragObject;

    private int saveAtWhichCheckpoint = -2; // the default value is -2 because -1 is the default value of PlayerPrefs Checkpoint and 0 is the lowest value of cheekpoint
    private float timeSpentTillCheckpoint;
    private float checkpointTimeRecord = 0;
    private float timeSpentTillPicked;
    private float PickedTimeRecord = 0;
    private Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    public void boxgrab()
    {
        rb.MovePosition(boxHolder.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickedTimeRecord = timeSpentTillPicked;
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

        if (GameManager.instance.reset)
        {
            ResetBox();
        }
    }

    void ResetBox()
    {
        if (saveAtWhichCheckpoint != PlayerPrefs.GetInt("CurrentCheckpoint") || PickedTimeRecord > checkpointTimeRecord)
        {
            transform.position = initialPosition;
        }

    }

}

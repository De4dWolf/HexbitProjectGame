using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Door : MonoBehaviour
{
    public Transform openposition;
    public float moveSpeed = 2.0f;
    private Vector3 initialPosition;
    private Vector3 newPosition;
    private int saveAtWhichCheckpoint = -2; // the default value is -2 because -1 is the default value of PlayerPrefs Checkpoint and 0 is the lowest value of cheekpoint
    private float startTime;
    private bool isMoving = false;

    void Start()
    {
        if (openposition != null)
        {
            initialPosition = transform.position;
        }
    }

    public void DoorOpen()
    {
        if (openposition != null && !isMoving)
        {
            startTime = Time.time;
            isMoving = true;
        }
    }

    void Update()
    {

        if (GameManager.instance.saving)
        {
            saveAtWhichCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
            newPosition = transform.position;
        }  
        
        if (GameManager.instance.reset)
        {
            if (newPosition == new Vector3(0, 0, 0))
            {
                transform.position = initialPosition;
            }
            else
            {
                transform.position = newPosition;
            }
        }

        if (isMoving)
        {
            float journeyLength = Vector3.Distance(initialPosition, openposition.position);
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, openposition.position, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                // The door has reached its open position
                if(saveAtWhichCheckpoint == PlayerPrefs.GetInt("CurrentCheckpoint"))
                {
                    newPosition = transform.position;

                }
                isMoving = false;
            }
        }

    }
}

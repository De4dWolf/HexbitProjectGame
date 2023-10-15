using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Door : MonoBehaviour
{
    public Transform openposition;
    public float moveSpeed = 2.0f;
    private Vector3 initialPosition;
    private float startTime;
    private bool isMoving = false;

    void Start()
    {
        if (openposition != null)
        {
            initialPosition = transform.position;
            
        }
    }

    public void dooropen()
    {
        if (openposition != null && !isMoving)
        {
            startTime = Time.time;
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            float journeyLength = Vector3.Distance(initialPosition, openposition.position);
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(initialPosition, openposition.position, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                // The door has reached its open position
                isMoving = false;
            }
        }
    }
}

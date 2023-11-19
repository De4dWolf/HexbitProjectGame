using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAreaScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Assuming you have a public method to modify moveSpeed in your PlayerController
                playerController.ApplySpeedBoost(10f); // Increase moveSpeed to 7
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                // Reset moveSpeed to its original value when exiting the trigger
                playerController.ApplySpeedBoost(5f); // Reset moveSpeed to 5
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

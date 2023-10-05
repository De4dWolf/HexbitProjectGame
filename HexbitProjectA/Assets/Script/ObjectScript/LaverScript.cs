using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class LaverScript : MonoBehaviour
{
    private bool playerInside = false;
    public GameObject UIText;
    public GameObject pintu;
    
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("player melewati laver");
            UIText.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Player exited laver");
            UIText.SetActive(false);
        }
    }

    private void dooropen()
    {
        pintu.SetActive(false);
    }

   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("player menyalakan laver");
            dooropen();
            transform.localRotation = quaternion.RotateZ(20);
        }
      
    }
}

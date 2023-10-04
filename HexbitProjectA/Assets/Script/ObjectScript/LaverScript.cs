using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaverScript : MonoBehaviour
{
    private bool playerInside = false;
    public GameObject UIText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player melewati laver");
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

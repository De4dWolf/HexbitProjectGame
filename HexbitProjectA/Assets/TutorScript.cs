using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorScript : MonoBehaviour
{
    public GameObject TutorialImage;
    public AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.CompareTag("Player"))
        {
            TutorialImage.SetActive(true);
            audioSource.Play();
           
        }

    }



    void Start()
    {
     
        
    }

   
    void Update()
    {
        
    }
}

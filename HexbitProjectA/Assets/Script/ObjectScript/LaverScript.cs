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
    private Animator anim;
    public GameObject Camera2;
    public Door door;

    public AudioSource SFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerInside = true;
            UIText.SetActive(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            UIText.SetActive(false);

        }
    }


   
    void Start()
    {
       /* anim = pintu.GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animasi Blm ada");
        }*/
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            SFX.Play();
            StartCoroutine(OpenDoorGradually());
            Debug.Log("player menyalakan laver");
            transform.localScale = new Vector3(-1f, 1f, 1f);
            // anim.SetTrigger("Buka");
            GameManager.instance.CameraChange(Camera2);
        }
    }

    IEnumerator OpenDoorGradually()
    {
        if (door != null)
        {
            door.DoorOpen();
        }

        yield return new WaitForSeconds(1.0f); // Adjust the time it takes to fully open the door
        Debug.Log("Door is fully open");
    }
}

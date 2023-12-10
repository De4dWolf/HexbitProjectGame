using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;
    private bool playerinside;
    private PlayerManager player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Save();
        }
    }

    private void Save()
    {
        Debug.Log(PlayerPrefs.GetInt("CurrentCheckpoint") + "Prefs");
        Debug.Log(checkpointID + "Checkpoint");

        if (PlayerPrefs.GetInt("CurrentCheckpoint") <= checkpointID)
        {
            player.RespawnPemain = transform.position;
            PlayerPrefs.SetInt("CurrentCheckpoint", checkpointID);
        }


    }
}

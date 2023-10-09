using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private int currentCheckpoint;
    public GameObject[] checkPoints;
    private GameObject playerInstance;

    void Start()
    {
        SpawnPlayer();
        Load();
        
    }

    void Update()
    {
        // Add any other game management logic here.
    }

    private void SpawnPlayer()
    {
        if (playerInstance != null)
        {
            Destroy(playerInstance); // Destroy the existing player object if it exists.
        }

        playerInstance = Instantiate(playerPrefab, checkPoints[currentCheckpoint].transform.position, Quaternion.identity);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("CurrentCheckpoint"))
        {
            currentCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
        }
    }
}

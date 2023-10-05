using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    [SerializeField] private GameObject playermodel;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private int currentCheckpoint;
    public GameObject[] checkPoints;
    void Start()
    {
        Load();
        SpawnPlayer();
    }

    
    void Update()
    {
       
    }

    private void SpawnPlayer()
    {
        Instantiate(playermodel, checkPoints[currentCheckpoint].transform.position, checkPoints[currentCheckpoint].transform.rotation);
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("CurrentCheckpoint"))
        {
            currentCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
        }
    }
}

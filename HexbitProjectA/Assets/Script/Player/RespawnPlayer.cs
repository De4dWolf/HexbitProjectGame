using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private GameObject pemain;
    void Start()
    {
        RespawnPemain();
    }

   public void RespawnPemain()
    {
        pemain = FindObjectOfType<PlayerController>().gameObject;
        pemain.transform.position = transform.position;
    }

    public void GameOver()
    {

    }
}

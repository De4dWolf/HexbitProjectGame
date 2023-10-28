using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    protected GameObject playerObject;
    protected PlayerManager player;

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {

    }
}

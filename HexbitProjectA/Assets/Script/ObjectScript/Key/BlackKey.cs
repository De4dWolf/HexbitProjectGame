using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKey : Key
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsCollected = true;
            player.BlackKey += 1;
            GetComponent<CircleCollider2D>().enabled = false;
            /*GetComponent<Animator>().SetTrigger("Picked");*/ // Destroy animation 
        }
    }
}


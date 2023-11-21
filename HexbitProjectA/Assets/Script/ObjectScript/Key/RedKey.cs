using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : Key
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsCollected = true;
            player.RedKey += 1;
            GetComponent<CircleCollider2D>().enabled = false;
            /*GetComponent<Animator>().SetTrigger("Picked");*/ // Destroy animation 
        }
    }
}

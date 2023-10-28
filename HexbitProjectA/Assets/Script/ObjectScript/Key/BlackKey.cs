using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKey : Key
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.BlackKey += 1;
            GetComponent<CircleCollider2D>().enabled = false;
            UIManager.Instance.UpdateKey(player.BlackKey, "black");
            /*GetComponent<Animator>().SetTrigger("Picked");*/ // Destroy animation 
        }
    }
}

// TO DO :
// 1. Sprite
// 2. Animation

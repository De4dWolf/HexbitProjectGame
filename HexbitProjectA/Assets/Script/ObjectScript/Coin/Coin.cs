using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    protected GameObject playerObject;
    protected PlayerManager player;
    private bool IsCollected = false;
    public GameObject target;


    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        target = GameObject.FindWithTag("Coin");
        player = playerObject.GetComponent<PlayerManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.coin += 1;
            GetComponent<CircleCollider2D>().enabled = false;
            UIManager.Instance.UpdateCoin(player.coin);
            IsCollected = true;
            Destroy(gameObject, 2f);
            GetComponent<Animator>().SetTrigger("Picked"); // Destroy animation 
        }
    }


    private void Update()
    {
        if (IsCollected)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, 8f * Time.deltaTime);
        }
    }
}

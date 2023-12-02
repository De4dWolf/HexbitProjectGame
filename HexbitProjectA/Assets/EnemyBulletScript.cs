using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public float force;
    private float timer;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    //hancurkan peluru
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            rb.velocity = new Vector2(0, 0);
            col.enabled = false;
            if (timer > 5)
            {
                Destroy(gameObject);
            }
        }
    }
}

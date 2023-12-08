using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    BoxCollider2D col;
    Rigidbody2D rb;
    Vector2 initialPosition;
    bool platformMovingBack;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (platformMovingBack)
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, 10f * Time.deltaTime);

        if (transform.position.y == initialPosition.y)
        {
            platformMovingBack = false;
            col.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player") && !platformMovingBack)
        {
            //waktu mau jatuh
            Invoke("DropPlatform", 0.5f);
        }
    }

    void DropPlatform()
    {
        col.enabled = false;
        rb.isKinematic = false;
        //lama jatuh
        Invoke("GetPlatformBack", 2f);
    }

    void GetPlatformBack()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        platformMovingBack = true;
    }
}

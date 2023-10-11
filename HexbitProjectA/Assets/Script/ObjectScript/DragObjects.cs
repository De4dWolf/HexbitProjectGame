using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 target;
    public Transform boxHolder;
    private Rigidbody2D rb;

    void Start()
    {
        target = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    public void boxgrab()
    {
        target = boxHolder.position;
        rb.MovePosition(target);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    public Transform boxHolder;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void boxgrab()
    {
        rb.MovePosition(boxHolder.position);
    }
}

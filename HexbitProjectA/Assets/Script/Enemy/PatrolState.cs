using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform ledgeDetector;
    public LayerMask groundLayer, obstacleLayer;

    private bool facingRight = true;
    public float raycastDistance, obstacleDistance;
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.right, obstacleDistance, obstacleLayer);
        Debug.DrawLine(ledgeDetector.position, hit.point, Color.red);
        Debug.DrawLine(ledgeDetector.position, hitObstacle.point, Color.blue);
        if (hit.collider == null || hitObstacle.collider == true)
        {
            Rotate();
        }
    }

    void FixedUpdate()
    {
        if(facingRight)
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(-speed, -rb.velocity.y);
    }

    void Rotate()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}

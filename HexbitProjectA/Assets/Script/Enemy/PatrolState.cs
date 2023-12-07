using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class PatrolState : MonoBehaviour
{
    public Rigidbody2D rb;
    //BoxCollider2D boxCollider2D;
    public Transform ledgeDetector;
    public LayerMask groundLayer, obstacleLayer;

    private bool facingRight = true;
    public float raycastDistance, obstacleDistance;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(ledgeDetector.position, Vector2.down, raycastDistance, groundLayer);
        RaycastHit2D hitObstacle = Physics2D.Raycast(ledgeDetector.position, Vector2.right, obstacleDistance, obstacleLayer);
        RaycastHit2D hitObstacle2 = Physics2D.Raycast(ledgeDetector.position, Vector2.left, obstacleDistance, obstacleLayer);
        Debug.DrawRay(ledgeDetector.position, Vector2.down * raycastDistance, Color.red);
        Debug.DrawRay(ledgeDetector.position, Vector2.right * obstacleDistance, Color.blue);
        Debug.DrawRay(ledgeDetector.position, Vector2.left * obstacleDistance, Color.yellow);

        if (hit.collider == null || hitObstacle.collider == true || hitObstacle2.collider == true)
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

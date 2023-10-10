using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    public GameObject CharacterControl2;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movement();
    }


    private void movement()
    {
        // Deteksi apakah karakter berada di atas tanah.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Mengontrol pergerakan karakter.
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (moveX < 0)
        {
           transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        

        // Melompat jika pemain menekan tombol lompat dan karakter berada di atas tanah.
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CharacterControl2.SetActive(false);
        }
    }
}

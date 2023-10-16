using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveX;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer,boxlayer;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    public GameObject CharacterControl2;

    private Animator anim;
    private bool isWalking;
    private bool isGrab;
    private bool isPull;
    private bool isPush;

    private bool hadapKanan = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        movement();
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isGrab", isGrab);
        anim.SetBool("isPull", isPull);
        anim.SetBool("isPush", isPush);
    }


    private void movement()
    {
        // Deteksi apakah karakter berada di atas tanah.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer,boxlayer);

        // Mengontrol pergerakan karakter.
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        if (!isGrab)
        {
            if (hadapKanan && moveX < 0)
            {
                Flip();
            }
            else if (!hadapKanan && moveX > 0)
            {
                Flip();
            }
            if(moveX == 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                isWalking = false;
            }
            else
            {
                isWalking = true;
            }
        }

        // Melompat jika pemain menekan tombol lompat dan karakter berada di atas tanah.
        if (isGrounded && Input.GetButtonDown("Jump") && !isGrab)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CharacterControl2.SetActive(false);
        }
    }

    private void Flip()
    {
        hadapKanan = !hadapKanan;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    //GrabObjects
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                isGrab = true;
                other.gameObject.GetComponent<DragObjects>().boxgrab();

                if (hadapKanan && moveX < 0)
                {
                    isPull = true;
                }
                else if (hadapKanan && moveX > 0)
                {
                    isPush = true;
                }
                else if (!hadapKanan && moveX < 0)
                {
                    isPush = true;
                }
                else if (!hadapKanan && moveX > 0)
                {
                    isPull = true;
                }
                else
                {
                    isPush = false;
                    isPull = false;
                }
            }
            else
            {
                isGrab = false;
            }
        }
                
    }
}

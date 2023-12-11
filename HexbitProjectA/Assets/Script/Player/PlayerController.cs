using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveX;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    public GameObject CharacterControl2;

    private Animator anim;
    private bool isWalking;
    private bool isGrab;
    private bool isPull;
    private bool isPush;

    public bool hadapKanan = true;

    private float verticalmove;
    private bool isOnLadder;
    private bool isClimbing;
    [SerializeField] private float maxJatuh = -30;

    public ParticleSystem Dust;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (DialogueManager.Instance.isDialogueActive)
        {
            rb.velocity = new Vector2(0,0);
            isWalking = false;
            return;
        }

        movement();

        verticalmove = Input.GetAxis("Vertical");
        if (isOnLadder && Mathf.Abs(verticalmove) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isGrab", isGrab);
        anim.SetBool("isPull", isPull);
        anim.SetBool("isPush", isPush);

        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * 4);
        }
        else
        {
             rb.gravityScale = 5f;
        }

        if(rb.velocity.y <= maxJatuh)
        {
            if (isGrounded)
            {
            }
        }
    }

    private void movement()
    {
        // Deteksi apakah karakter berada di atas tanah.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Mengontrol pergerakan karakter.
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        if (!isGrab)
        {
            if (hadapKanan && moveX < 0)
            {
                Flip();
                CreateDust();
            }
            else if (!hadapKanan && moveX > 0)
            {
                Flip();
                CreateDust();
            }
            if (moveX == 0)
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
            CreateDust();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CharacterControl2.SetActive(false);
        }
    }

    public void Flip()
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

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    // Hanya jalankan animasi isPull atau isPush jika tombol A atau D ditekan
                    if (hadapKanan && moveX < 0)
                    {
                        isPull = true;
                        isPush = false;
                    }
                    else if (hadapKanan && moveX > 0)
                    {
                        isPush = true;
                        isPull = false;
                    }
                    else if (!hadapKanan && moveX < 0)
                    {
                        isPush = true;
                        isPull = false;
                    }
                    else if (!hadapKanan && moveX > 0)
                    {
                        isPull = true;
                        isPush = false;
                    }
                    else
                    {
                        isPush = false;
                        isPull = false;
                    }
                }
                else
                {
                    // Jika tombol F ditekan tetapi tombol A atau D tidak ditekan, atur animasi menjadi false
                    isPush = false;
                    isPull = false;
                }
            }
            else
            {
                isGrab = false;
                isPush = false;
                isPull = false;
            }
        }
    }


    public void ApplySpeedBoost(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }



    //tangga code
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tangga"))
        {
            isOnLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Tangga"))
        {
            isOnLadder = false;
            isClimbing = false;
        }
    }

    private void CreateDust()
    {
        Dust.Play();
    }
}

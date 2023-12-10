using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float groundCheckRadius = 1f;

    public AudioSource grass;
    public AudioSource rock;
    public AudioSource wood;

    private void Awake()
    {
        grass = GameObject.Find("Footstep Grass").GetComponent<AudioSource>();
        rock = GameObject.Find("Footstep Rock").GetComponent<AudioSource>();
        wood = GameObject.Find("Footstep Wood").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, Color.red);

    }

    private void Step()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);
        if (hit.collider != null && hit.collider.tag != null)
        {
            if (hit.collider.CompareTag("Grass"))
            {
                grass.Play();
            }
            if (hit.collider.CompareTag("Rock"))
            {
                rock.Play();
            }
            if (hit.collider.CompareTag("Wood"))
            {
                wood.Play();
            }
        }
    }
}

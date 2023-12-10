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
    public AudioSource Wood;

    private void FixedUpdate()
    {
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, Color.red);
    }

    private void Step()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);
        if (hit.collider.tag == "Grass")
        {
            grass.Play();
        }
        if (hit.collider.tag == "Rock")
        {
            rock.Play();
        }
        if (hit.collider.tag == "Wood")
        {
            Wood.Play();
        }
    }
}

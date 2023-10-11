using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet_AI : MonoBehaviour
{
    public float speed;
    public float distance;
    public float jumpPower;
    Transform player;
    public Transform spawn;
    //Animator anim;
    Rigidbody2D rig;
    public LayerMask groundLayer;
    public float teldistance;

    //public ParticleSystem tel;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        Physics2D.IgnoreLayerCollision(6, 7);
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - player.position.x) > distance)
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            //anim.SetBool("isWalk", true);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * -1f, 0.5f, groundLayer);

            RaycastHit2D hitdia = Physics2D.Raycast(transform.position, new Vector2(1 * DirectionPet(), 1), 7f, groundLayer);

            if (spawn.position.y - transform.position.y <= 0)
                hitdia = new RaycastHit2D();

            if (hit || hitdia)
            {
                rig.velocity = Vector2.up * jumpPower;
            }
        }
        else
        {
            //anim.SetBool("isWalk", false);
        }
        
        if (Vector2.Distance(player.position, transform.position) > teldistance)
        {
            transform.position = spawn.position;
            //tel.gameObject.SetActive(true);
            //tel.Play();
        }
        /* Kalau udah ada texture effect
        if (!tel.isPlaying)
        {
            tel.gameObject.SetActive(false);
        }
        */
    }

    float DirectionPet()
    {
        if (transform.position.x - player.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            return 1;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            return -1;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;
    public Animator anim;
    public bool aim = false;

    public float jarakMax = 15f;
    public float rotasiAtas= -130;
    public float rotasiBawah = -200;


    //private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        //hadap
        if (rot <= rotasiAtas && rot >= rotasiBawah)
        {
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }

        anim.SetBool("Aim", aim);

        //jarak max player untuk menembak
        if (distance < jarakMax && rot <= rotasiAtas && rot >= rotasiBawah)
        {
            aim = true;

            /*
            timer += Time.deltaTime;
            
            //jeda menembak
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
            */
        }
        else
        {
            aim = false;
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}

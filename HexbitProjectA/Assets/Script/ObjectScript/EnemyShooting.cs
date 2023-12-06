using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    private float timer;

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
        if (rot <= 0 && rot >= -75)
        {
            transform.rotation = Quaternion.Euler(0, 0, rot);
        }

        //jarak max player untuk menembak
        if(distance < 15 && rot <= 0 && rot >= -75)
        {
            timer += Time.deltaTime;

            //jeda menembak
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}

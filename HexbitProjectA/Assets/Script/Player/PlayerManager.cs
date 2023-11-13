using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private float fallHeightThreshold = 10f;
    private bool isFalling = false;

    private Vector3 RespawnPemain;

    [SerializeField] private UIManager _UIManager;
    [SerializeField] private int redKey;
    [SerializeField] private int blackKey;
    public int coin;
    void Start()
    {
      RespawnPemain = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Void")
        {
            transform.position = RespawnPemain;
        }
        else if (collision.tag == "CheckPoint")
        {
            RespawnPemain = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /*void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("anda mati");
    }*/

    public int RedKey { 
        get 
        { 
            return redKey; 
        } 
        set 
        {
            redKey = value;
        }
    }

    public int BlackKey
    {
        get
        {
            return blackKey;
        }
        set
        {
            blackKey = value;
        }
    }


}

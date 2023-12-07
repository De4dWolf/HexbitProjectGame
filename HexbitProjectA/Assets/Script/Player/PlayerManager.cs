using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private float fallHeightThreshold = 10f;
    [SerializeField] GameObject gameOver;

    public string diedFrom;
    public bool isDeath = false;
    

    public Vector3 RespawnPemain;

    [SerializeField] private UIManager _UIManager;
    [SerializeField] private int _redkey;
    [SerializeField] private int _blackkey;
    public int coin;
    void Start()
    {
      RespawnPemain = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CheckPoint")
        {
            RespawnPemain = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        
          
        if (other.gameObject.tag == "Void" || other.gameObject.tag == "Enemy")
        {
            Debug.Log(diedFrom);
            diedFrom = LayerMask.LayerToName(other.gameObject.layer);
            gameOver.SetActive(true);
        }
    }




    // Update is called once per frame
    void Update()
    {
        if(isDeath)
        {
            transform.position = RespawnPemain;
        }
    }

    /*void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("anda mati");
    }*/

    public int RedKey { 
        get 
        { 
            return _redkey; 
        } 
        set 
        {
            _redkey = value;
            UIManager.Instance.UpdateKey(_redkey, "red");
        }
    }

    public int BlackKey
    {
        get
        {
            return _blackkey;
        }
        set
        {
            _blackkey = value;
            UIManager.Instance.UpdateKey(_blackkey, "black");
        }
    }


}

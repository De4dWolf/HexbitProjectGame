using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private float fallHeightThreshold = 10f;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private PlayerController playerController;

    public string diedFrom;
    public bool isDeath = false;
    

    public Vector3 RespawnPemain;

    [SerializeField] private UIManager _UIManager;
    [SerializeField] private int _redkey;
    [SerializeField] private int _blackkey;
    public int coin;

    void Awake()
    {
        gameOver = GameManager.ReturnDecendantOfParent(GameObject.Find("Game Over Canvas"), "Game Over");
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("CurrentCheckpoint", 0);
        RespawnPemain = transform.position;
    }




    private void OnCollisionEnter2D(Collision2D other)
    {

        
          
        if (other.gameObject.tag == "Void" || other.gameObject.tag == "Enemy")
        {
            diedFrom = LayerMask.LayerToName(other.gameObject.layer);
            Debug.Log(diedFrom);

            gameOver.SetActive(true);
        }
    }




    // Update is called once per frame
    void Update()
    {

        if (isDeath)
        {
            if (Mathf.Round(transform.eulerAngles.y) == 180)
            {
                playerController.Flip();
            }

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

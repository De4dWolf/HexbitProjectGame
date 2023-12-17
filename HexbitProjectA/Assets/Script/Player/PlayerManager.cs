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
    public bool isRespawn = false;
    public bool isDeath = false;

    public Vector3 RespawnPemain;

    [SerializeField] private UIManager _UIManager;
    [SerializeField] private int _redfire;
    [SerializeField] private int _bluefire;
    public int coin;

    void Awake()
    {
        gameOver = GameManager.ReturnDecendantOfParent(GameObject.Find("Game Over Canvas"), "Game Over");
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("CurrentCheckpoint", -1);
        RespawnPemain = transform.position;
    }




    private void OnCollisionEnter2D(Collision2D other)
    {

        
          
        if (other.gameObject.tag == "Void" || other.gameObject.tag == "Enemy")
        {
            diedFrom = LayerMask.LayerToName(other.gameObject.layer);
            isDeath = true;
            gameOver.SetActive(true);
        }
    }




    // Update is called once per frame
    void Update()
    {

        if (isRespawn)
        {
            if (Mathf.Round(transform.eulerAngles.y) == 180)
            {
                playerController.Flip();
            }
            transform.position = RespawnPemain;
            isRespawn = false;
            GameManager.instance.ResetState();

        }
    }

    /*void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("anda mati");
    }*/

    public int RedFire { 
        get 
        { 
            return _redfire; 
        } 
        set 
        {
            _redfire = value;
            UIManager.Instance.UpdateFire(_redfire, "red");
        }
    }

    public int BlueFire
    {
        get
        {
            return _bluefire;
        }
        set
        {
            _bluefire = value;
            UIManager.Instance.UpdateFire(_bluefire, "blue");
        }
    }


}

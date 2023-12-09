using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class LeverWithKey : MonoBehaviour
{
    private bool playerInside = false;
    private bool doorOpen = false;
    public bool IsNeedRedKey;
    private string key;

    protected GameObject playerObject;
    protected PlayerManager player;

    public GameObject UIText;
    private TextMeshProUGUI message;
    private Animator anim;
    public GameObject Camera2;
    [SerializeField] private GameObject Particle;

    public Door door;

    public AudioSource SFX;

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();
        message = UIText.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (IsNeedRedKey)
        {
            key = "Blue Fire";
        }
        else
        {
            key = "Red Fire";
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            if (!doorOpen)
            {
                UIText.SetActive(true);
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("Player exited laver");
            UIText.SetActive(false);
        }
    }



    void Update()
    {
        if (playerInside && !doorOpen && Input.GetKeyDown(KeyCode.E))
        {

            if (IsNeedRedKey)
            {
                if (player.RedKey > 0)
                {
                    SFX.Play();
                    StartCoroutine(OpenDoorGradually());
                    transform.localRotation = quaternion.RotateY(160);
                    Particle.SetActive(true);
                    // anim.SetTrigger("Buka");

                    GameManager.instance.camerachange(Camera2);
                    player.RedKey -= 1;
                    doorOpen = true;
                }
                else
                {
                    StartCoroutine(MessageFeedback(key + " is Required", 1.2f));
                    
                };

            }
            else {
                if (player.BlackKey > 0)
                {
                    SFX.Play();
                    StartCoroutine(OpenDoorGradually());
                    //transform.localRotation = quaternion.RotateY(160);
                    // anim.SetTrigger("Buka");
                    GameManager.instance.camerachange(Camera2);
                    Particle.SetActive(true);

                    doorOpen = true;
                    player.BlackKey -= 1;
                }
                else
                {
                    StartCoroutine(MessageFeedback(key + " is Required", 1.2f));
                }
            }
        }

        IEnumerator OpenDoorGradually()
        {
            if (door != null)
            {
                door.dooropen();
            }

            yield return new WaitForSeconds(1.0f); // Adjust the time it takes to fully open the door
        }

        IEnumerator MessageFeedback(string newText, float delayTime)
        {
            message.text = newText;
            yield return new WaitForSeconds(delayTime);
            message.text = "Press E";
        }
    }
}

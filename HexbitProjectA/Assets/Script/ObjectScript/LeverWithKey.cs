using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class LeverWithKey : MonoBehaviour
{
    private bool playerInside = false;
    private bool doorOpen = false;
    public bool IsNeedRedFire;
    private string key;
    private bool fireConsumed = false;
    private int saveAtWhichCheckpoint = -2; // the default value is -2 because -1 is the default value of PlayerPrefs Checkpoint and 0 is the lowest value of cheekpoint

    private float timeSpentTillCheckpoint;
    private float checkpointTimeRecord = 0;
    private float timeSpentTillPicked;
    private float PickedTimeRecord = 0;


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
        if (IsNeedRedFire)
        {
            key = "Red Fire";
        }
        else
        {
            key = "Blue Fire";
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
            UIText.SetActive(false);
        }
    }

    void Update()
    {

        timeSpentTillCheckpoint += Time.time;
        timeSpentTillPicked += Time.time;


        if (GameManager.instance.saving)
        {
            saveAtWhichCheckpoint = PlayerPrefs.GetInt("CurrentCheckpoint");
            checkpointTimeRecord = timeSpentTillCheckpoint;
        }

        if ( GameManager.instance.reset && fireConsumed)
        { 
            fireConsumed = false;
            RevertChanges();
        }


        if (playerInside && !doorOpen && Input.GetKeyDown(KeyCode.E))
        {

            if (IsNeedRedFire)
            {
                if (player.RedFire > 0)
                {
                    SFX.Play();
                    StartCoroutine(OpenDoorGradually());
                    transform.localRotation = quaternion.RotateY(160);
                    Particle.SetActive(true);
                    // anim.SetTrigger("Buka");
                    fireConsumed = true;
                    GameManager.instance.CameraChange(Camera2);
                    player.RedFire -= 1;
                    doorOpen = true;
                    PickedTimeRecord = timeSpentTillPicked;
                }
                else
                {
                    StartCoroutine(MessageFeedback(key + " is Required", 1.2f));
                    
                };

            }
            else {
                if (player.BlueFire > 0)
                {
                    SFX.Play();
                    StartCoroutine(OpenDoorGradually());
                    // anim.SetTrigger("Buka");
                    fireConsumed = true;
                    GameManager.instance.CameraChange(Camera2);
                    Particle.SetActive(true);
                    PickedTimeRecord = timeSpentTillPicked;
                    doorOpen = true;
                    player.BlueFire -= 1;
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
                door.DoorOpen();
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

    private void RevertChanges()
    {
        if (saveAtWhichCheckpoint != PlayerPrefs.GetInt("CurrentCheckpoint") || PickedTimeRecord > checkpointTimeRecord)
        {
            Particle.SetActive(false);
            doorOpen = false;

            if(fireConsumed)
            {
                if (IsNeedRedFire)
                {
                    player.RedFire += 1;
                }
                else
                {
                    player.BlueFire += 1;
                }
            }
            
        }
    }
}

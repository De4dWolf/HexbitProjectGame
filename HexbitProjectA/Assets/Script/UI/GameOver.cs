using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject blackBar;
    [SerializeField] private PlayerManager player;
    [SerializeField] private GameObject diedMessageObject;
    [SerializeField] private TextMeshProUGUI diedMessageText;
    [SerializeField] private GameObject audioManagerObject;
    [SerializeField] private AudioManager audioManager;
    private AudioSource SFX;
    public AudioSource[] deathSFX;

    private bool audioPlayed = false;

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();
        diedMessageObject = GameObject.Find("DiedMessage");
        diedMessageText = diedMessageObject.GetComponent<TextMeshProUGUI>();
        audioManagerObject = GameObject.Find("SFX");
        audioManager = audioManagerObject.GetComponent<AudioManager>();

    }

    private void Start()
    {
        Debug.Log(player);
        movementcancel();
    }


    private void Update()
    {
        deathSentence();

        if (!audioPlayed)
        {
            // Add death audio here 
            audioManager.backroundAudio.Stop();
            SFX.Play();
            audioPlayed = true;
        }

    }

    void deathSentence()
    {

        if (player.diedFrom == "Spike"){
            diedMessageText.text = "you've been pierced";
            SFX = deathSFX[0];
        } else if (player.diedFrom == "Air")
        {
            SFX = deathSFX[1];
            diedMessageText.text = "you've been drowned";
        }

        
    }


    void movementcancel()
    {
        PlayerController Scripttodisable = playerObject.GetComponent<PlayerController>();
        Scripttodisable.enabled = false;
    }

    void movementenable()
    {
        PlayerController Scripttodisable = playerObject.GetComponent<PlayerController>();
        Scripttodisable.enabled = true;
    }

    public void TryAgain()
    {
        player.isDeath = true;
        blackBar.SetActive(true);
        Invoke("DestroyGameOver", 0.7f);
        Invoke("DestroyBlackBar", 1.115f);
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
        Invoke("DestroyGameOver", 0.7f);
        Invoke("DestroyBlackBar", 1.115f);

    }

    private void DestroyGameOver()
    {
        audioManager.backroundAudio.Play();
        player.isDeath = false;
        audioPlayed = false;
        gameObject.SetActive(false);

    }

    private void DestroyBlackBar()
    {
        blackBar.SetActive(false);
        movementenable();


    }

    // Death Sound Credits

    // Spike = https://freesound.org/people/SilverIllusionist/sounds/472689/ 
    // Drowned = https://www.youtube.com/watch?v=NvdEVysHzgA

}

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
    
    private AudioSource SFX;
    public AudioSource[] deathSFX;
    public AudioSource SFX1;
    public AudioSource SFX2;

    private bool audioPlayed = false;

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();
        blackBar = GameManager.ReturnDecendantOfParent(GameObject.Find("Main Camera"), "GameOverBackground");
        diedMessageText = GameManager.ReturnDecendantOfParent(gameObject, "Died Message").GetComponent<TextMeshProUGUI>();

        //SFX1 = GameObject.Find("PlayerDied_Spike").GetComponent<AudioSource>();
        //SFX2 = GameObject.Find("PlayerDied_Drowned").GetComponent<AudioSource>();
        //deathSFX = new AudioSource[2];
        //deathSFX[0] = SFX1;
        //deathSFX[1] = SFX2;

    }

    private void Start()
    {
        movementcancel();


    }


    private void Update()
    {

        if (!audioPlayed)
        {
            // Add death audio here 
            AudioManager.instance.backroundAudio.Stop();
            //SFX.Play();
            audioPlayed = true;
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
        AudioManager.instance.backroundAudio.Play();
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

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

    private bool audioPlayed = false;

    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<PlayerManager>();
        blackBar = GameManager.ReturnDecendantOfParent(GameObject.Find("Main Camera"), "GameOverBackground");
        diedMessageText = GameManager.ReturnDecendantOfParent(gameObject, "Died Message").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
    }


    private void Update()
    {
        if (player.isDeath)
        {
            movementcancel();

        }

        if (!audioPlayed)
        {
            // Add death audio here 
            AudioManager.instance.backroundAudio.Stop();
            audioPlayed = true;
        }

    }



    void movementcancel()
    {
        playerObject.GetComponent<SpriteRenderer>().enabled = false;
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
        player.isRespawn = true;
        audioPlayed = false;
        gameObject.SetActive(false);

    }

    private void DestroyBlackBar()
    {
        playerObject.GetComponent<SpriteRenderer>().enabled = true;
        player.isRespawn = false;
        player.isDeath = false;
        blackBar.SetActive(false);
        movementenable();


    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject concedeMenu;
    [SerializeField] GameObject Player;

    public AudioSource audiopause;
    public AudioSource audioresume;

    public static bool isPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
          
            movementcancel();
            if (!isPaused)
            {
                audiopause.Play();
                Pause();
            } else
            {
                audioresume.Play();
                Resume();
                concedeMenu.SetActive(false);
                optionsMenu.SetActive(false);
            }
        }
    }

    

    void movementcancel()
    {
        PlayerController Scripttodisable = Player.GetComponent<PlayerController>();
        Scripttodisable.enabled = false;
    }

    void movementenable()
    {
        PlayerController Scripttodisable = Player.GetComponent<PlayerController>();
        Scripttodisable.enabled = true;
    }

    void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        movementenable();
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        concedeMenu.SetActive(false);
    }

    public void Concede()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        concedeMenu.SetActive(true);
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        concedeMenu.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1;
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        concedeMenu.SetActive(false);
    }
}

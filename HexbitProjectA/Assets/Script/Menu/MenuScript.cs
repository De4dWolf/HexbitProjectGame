using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;

    public void Playgame()
    {
        this.Wait(0.5f, () =>
        {
            SceneManager.LoadScene("Level 1");
        });
    }

    public void Options()
    {
        this.Wait(0.5f, () =>
        optionsMenu.SetActive(true));

    }

    public void CreditScene()
    {
        this.Wait(0.5f, () =>
        SceneManager.LoadScene("Credit"));
    }

    public void Back()
    {
        this.Wait(0.5f, () =>
        optionsMenu.SetActive(false));
    }
}

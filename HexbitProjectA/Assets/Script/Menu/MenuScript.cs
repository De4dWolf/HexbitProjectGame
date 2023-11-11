using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;

    public void Playgame()
    {
        SceneManager.LoadScene("PlayGround");
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }

    public void Back()
    {
        optionsMenu.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("PlayGround");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitle;
    [SerializeField] private string[] subtitleText;
    [SerializeField] private int currentText;
    [SerializeField] private string levelToLoad;

    public void setText()
    {
        subtitle.text = subtitleText[currentText];
        currentText++;
    }
    public void onstartCutscene()
    {
        setText();
    }
    public void onFinishCutscene()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(levelToLoad);
    }
}

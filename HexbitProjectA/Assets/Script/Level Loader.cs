using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public GameObject transisi;

    public Animator transition;

    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LoadLevel(sceneIndex);
        }
    }

    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronusly(sceneIndex));
    }

    IEnumerator LoadAsynchronusly (int sceneIndex)
    {
        transisi.SetActive(true);
        transition.SetTrigger("fadeIn");
        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(1);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            //visual slider dan text
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}

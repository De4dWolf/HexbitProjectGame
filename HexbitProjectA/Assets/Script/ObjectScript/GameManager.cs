using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this; 
    }
    public GameObject camerautama;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void camerachange(GameObject camera)
    {
        camerautama.SetActive(false);
        camera.SetActive(true);
        StartCoroutine(Camerachange());
        IEnumerator Camerachange()
        {
            yield return new WaitForSeconds(2);
            camerautama.SetActive(true);
            camera.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

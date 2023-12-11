using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject camerautama;
    public bool saving = false;
    public bool reset = false;
    public bool trigger = false;

    private void Awake()
    {
        instance = this; 
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CameraChange(GameObject camera)
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

    public static GameObject descendant = null;
    public static GameObject ReturnDecendantOfParent(GameObject parent, string descendantName)
    {

        foreach (Transform child in parent.transform)
        {
            if (child.name == descendantName)
            {
                descendant = child.gameObject;
                break;
            }
            else
            {
                ReturnDecendantOfParent(child.gameObject, descendantName);
            }
        }
        return descendant;
    }

    public void SaveState()
    {
        StartCoroutine(Save());
        
        IEnumerator Save()
        {
            saving = true;
            yield return null;
            saving = false;
        }
    }

    public void ResetState()
    {
        StartCoroutine(Reset());

        IEnumerator Reset()
        {
            reset = true;
            yield return null;
            reset = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

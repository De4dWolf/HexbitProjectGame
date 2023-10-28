using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI redKeyText;
    [SerializeField] private TextMeshProUGUI blackKeyText;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateKey(float value, string key)
    {
        if (key == "red")
        {
            redKeyText.text = "x " + value.ToString();
        } else if (key == "black")
        {
            blackKeyText.text = "x " + value.ToString();
        }
    }
}

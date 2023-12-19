using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI redFireText;
    [SerializeField] private TextMeshProUGUI blueFireText;
    [SerializeField] private TextMeshProUGUI coinText;
    public static UIManager Instance;

    private void Awake()
    {
        redFireText = GameObject.Find("Red Fire Text").GetComponent<TextMeshProUGUI>();
        blueFireText = GameObject.Find("Blue Fire Text").GetComponent<TextMeshProUGUI>();
        Instance = this;
    }

    public void UpdateFire(float value, string key)
    {
        if (key == "red")
        {
            redFireText.text = "x " + value.ToString();
        } else if (key == "blue")
        {
            blueFireText.text = "x " + value.ToString();
        }
    }

    public void UpdateCoin(float value) 
    {
        coinText.text = value.ToString();
    }
}

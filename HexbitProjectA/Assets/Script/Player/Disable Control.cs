using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableControl : MonoBehaviour
{
    [SerializeField] GameObject Player;

    public void EnableControls()
    {
        PlayerController Scripttodisable = Player.GetComponent<PlayerController>();
        Scripttodisable.enabled = false;
    }

    public void DisableControls()
    {
        PlayerController Scripttodisable = Player.GetComponent<PlayerController>();
        Scripttodisable.enabled = true;
    }
}

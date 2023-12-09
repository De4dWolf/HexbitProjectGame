using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransisiLevelAwal : MonoBehaviour
{
    public GameObject transisi;
    public Animator transition;

    void Awake()
    {
        transition.SetTrigger("mulai");

        this.Wait(5, () =>
        transisi.SetActive(false));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Ui unity untuk cabang jawaban
public class Response
{
    [SerializeField] private string responseText;
    [SerializeField] private DialogueObject dialogueObject;

    public string ResponseText => responseText;

    public DialogueObject DialogueObject => dialogueObject;
}

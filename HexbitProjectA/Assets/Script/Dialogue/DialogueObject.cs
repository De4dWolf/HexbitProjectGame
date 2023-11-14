using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Membuat UI menu pada unity
[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    [SerializeField][TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;



    public string[] Dialogue => dialogue;

    public bool HasResponses => Responses != null && responses.Length > 0;

    public Response[] Responses => responses;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//Refresh List pada NPC
[CustomEditor(typeof(DialogueResponseEvents))]

public class DialogueResponseEventsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueResponseEvents responseEvents = (DialogueResponseEvents)target;

        if (GUILayout.Button("Refresh"))
        {
            responseEvents.OnValidate();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIconKanan;
    public Image characterIconKiri;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;
    
	public bool isDialogueActive = false;

	public float typingSpeed = 0.2f;

	public Animator animator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

		lines = new Queue<DialogueLine>();
    }

    private void Update()
    {
		if (isDialogueActive)
		{
            if (Input.GetKeyDown(KeyCode.Space))
			{
                DisplayNextDialogueLine();
            }   
        }
    }

    public void StartDialogue(Dialogue dialogue)
	{
        isDialogueActive = true;

        animator.Play("show");

		lines.Clear();

		foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
		{
			lines.Enqueue(dialogueLine);
		}

		DisplayNextDialogueLine();
	}

	public void DisplayNextDialogueLine()
	{
        if (isDialogueActive)
            if (lines.Count == 0)
			{
				EndDialogue();
				return;
			}

        DialogueLine currentLine = lines.Dequeue();

		characterIconKanan.sprite = currentLine.character.iconKanan;
        characterIconKiri.sprite = currentLine.character.iconKiri;
        characterName.text = currentLine.character.name;

		StopAllCoroutines();

		StartCoroutine(TypeSentence(currentLine));
	}

	IEnumerator TypeSentence(DialogueLine dialogueLine)
	{
		dialogueArea.text = "";
		foreach (char letter in dialogueLine.line.ToCharArray())
		{
			dialogueArea.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
	}

	void EndDialogue()
	{
        isDialogueActive = false;
		animator.Play("hide");
    }
}

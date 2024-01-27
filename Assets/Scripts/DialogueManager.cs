using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;
    private TextMeshProUGUI characterName;
    public Transform dialogueBox;
    public List<DialogueLine> dialogueLines;
    private int currentLine;
    public bool dialogueAutostart;
    private string currentDialogueText;

    void Start()
    {
        characterName = dialogueBox.GetChild(0).GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueBox.GetChild(1).GetComponent<TextMeshProUGUI>();
        currentLine = 0;
        if(dialogueAutostart)
            ShowNextLine();
    }

    void ShowDialogue(DialogueLine dialogue){
        characterName.text = dialogue.name;
        currentDialogueText = dialogue.text;
        StartCoroutine(WriteSlowly());
    }

    public void ShowNextLine(){
        if(currentLine == dialogueLines.Count){
            EndDialogue();
            return;
        }
        ShowDialogue(dialogueLines[currentLine++]);
    }

    void EndDialogue(){
        dialogueBox.gameObject.SetActive(false);
    }

    IEnumerator WriteSlowly(){
        dialogueText.text = "";
        foreach(char c in currentDialogueText)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
	public ScreenFader screenFader;
	public ButtonEnabler[] buttonEnablers;
	public string nextSceneName;
	
	private TextMeshProUGUI dialogueText;
	private TextMeshProUGUI characterName;
	public Transform dialogueBox;
	public List<DialogueLine> dialogueLines;
	private int currentLine;
	public bool dialogueAutostart;
	private string currentDialogueText;
	private float writeTimer = 0f;
	private int currentLetterIndex = 0;
	private bool canWrite = false;
	private AudioSource audioSource;

	void Awake() => audioSource = GetComponent<AudioSource>();

	void Start()
	{
		characterName = dialogueBox.GetChild(0).GetComponent<TextMeshProUGUI>();
		dialogueText = dialogueBox.GetChild(1).GetComponent<TextMeshProUGUI>();
		currentLine = 0;

		if(dialogueAutostart)
		{
			characterName.text = dialogueLines[currentLine].name;
			currentDialogueText = dialogueLines[currentLine].text;
			dialogueText.text = string.Empty;
			
			Invoke(nameof(ShowNextLine), screenFader.duration);
		}
	}

	void Update() => UpdateWriteTimer();

	void UpdateWriteTimer()
	{
		if(!canWrite)
		{
			return;
		}
		
		if(writeTimer <= 0 && currentLetterIndex < currentDialogueText.Length)
		{
			dialogueText.text += currentDialogueText[currentLetterIndex++];
			writeTimer = 0.05f;

			audioSource.Play();
		}
		else
		{
			writeTimer -= Time.deltaTime;
		}
	}

	void ShowDialogue(DialogueLine dialogue){
		characterName.text = dialogue.name;
		currentDialogueText = dialogue.text;
		dialogueText.text = string.Empty;
		currentLetterIndex = 0;

		dialogue.onDisplay.Invoke();
	}

	public void ShowNextLine(){
		canWrite = true;

		if(currentLine == dialogueLines.Count){
			EndDialogue();

			canWrite = false;

			return;
		}
		ShowDialogue(dialogueLines[currentLine++]);
	}

	void EndDialogue(){
		dialogueBox.gameObject.SetActive(false);

		screenFader.isFadingOut = false;

		DisableAllButtons();
		Invoke(nameof(OnDialogueEnd), screenFader.duration);
	}

	private void OnDialogueEnd() => SceneManager.LoadScene(nextSceneName);

	private void DisableAllButtons()
	{
		foreach (ButtonEnabler be in buttonEnablers)
		{
			be.SetInteractable(false);
		}
	}
}
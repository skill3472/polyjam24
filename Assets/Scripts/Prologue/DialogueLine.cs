using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueLine
{
	public string name;
	[TextArea(3,10)] public string text;
	public UnityEvent onDisplay;

	public DialogueLine(string name, string text)
	{
		this.name = name;
		this.text = text;
	}
}
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Player Progress")]
public class PlayerProgress : ScriptableObject
{
	public string lastSceneName;

	public void ResetValues() => lastSceneName = string.Empty;
}
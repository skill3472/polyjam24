using UnityEngine;
using UnityEngine.UI;

public class ButtonEnabler : MonoBehaviour
{
	public ScreenFader screenFader;
	
	private Button button;

	public void SetInteractable(bool interactable) => button.interactable = interactable;

	private void Awake() => button = GetComponent<Button>();
	private void EnableButton() => SetInteractable(true);

	private void Start()
	{
		SetInteractable(false);
		Invoke(nameof(EnableButton), screenFader.duration);
	}
}
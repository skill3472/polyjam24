using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public ScreenFader screenFader;
	public ButtonEnabler[] buttonEnablers;
	public PlayerProgress playerProgress;
	
	public void StartGame() => OnClick(nameof(OnGameStart));
	public void QuitGame() => OnClick(nameof(OnQuit));

	private void OnGameStart() => SceneManager.LoadScene("Prologue");
	private void OnQuit() => Application.Quit();

	private void OnClick(string methodName)
	{
		screenFader.isFadingOut = false;

		playerProgress.ResetValues();
		DisableAllButtons();
		Invoke(methodName, screenFader.duration);
	}

	private void DisableAllButtons()
	{
		foreach (ButtonEnabler be in buttonEnablers)
		{
			be.SetInteractable(false);
		}
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public PlayerProgress playerProgress;

	private void Start()
	{
		GameObject mmObject = GameObject.FindGameObjectWithTag("Music Manager");

		if(mmObject.TryGetComponent(out MusicManager mm))
		{
			mm.StopMusic();
		}
	}

	public void Retry() => SceneManager.LoadScene(playerProgress.lastSceneName);
	public void MainMenu() => SceneManager.LoadScene("Main Menu");
}
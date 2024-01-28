using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilogueTrigger : MonoBehaviour
{
	public ScreenFader screenFader;
	
	public void LoadEpilogue() => StartCoroutine(OnLoad());

	private IEnumerator OnLoad()
	{
		yield return new WaitForSeconds(2);

		screenFader.isFadingOut = false;

		yield return new WaitForSeconds(screenFader.duration);
		
		SceneManager.LoadScene("Epilogue");
	}
}
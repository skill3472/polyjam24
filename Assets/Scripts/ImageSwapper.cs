using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ImageSwapper : MonoBehaviour
{
	public ImageSequence[] sequences;
	public Image image;
	public ScreenFader screenFader;

	private void Start()
	{
		StartCoroutine(SwapImages());
	}

	private IEnumerator SwapImages()
	{
		foreach (ImageSequence sequence in sequences)
		{
			sequence.onDisplay.Invoke();
			
			image.sprite = sequence.image;

			yield return new WaitForSeconds(sequence.duration);

			screenFader.isFadingOut = false;

			yield return new WaitForSeconds(screenFader.duration);

			screenFader.isFadingOut = true;
		}

		SceneManager.LoadScene("Main Menu");
	}
}

[System.Serializable]
public class ImageSequence
{
	[Min(0.01f)] public float duration = 1f;
	public Sprite image;
	public UnityEvent onDisplay;
}
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
	public bool isFadingOut = true;
	[Min(0.01f)] public float duration = 1f;
	
	private RawImage image;

	private void Awake() => image = GetComponent<RawImage>();

	private void Update()
	{
		if(AlphaNotReachedTarget())
		{
			ModifyAlpha();
		}
	}

	private bool AlphaNotReachedTarget()
	{
		float target = isFadingOut ? 0f : 1f;

		return image.color.a != target;
	}

	private void ModifyAlpha()
	{
		Color color = image.color;
		int fadeDirection = isFadingOut ? -1 : 1;
		float step = fadeDirection*Time.deltaTime / duration;

		color.a = Mathf.Clamp(image.color.a + step, 0f, 1f);
		image.color = color;
	}
}
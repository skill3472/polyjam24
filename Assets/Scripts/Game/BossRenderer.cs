using UnityEngine;

public class BossRenderer : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

	public void SetDamageState(float duration)
	{
		SetAlpha(0.5f);
		Invoke(nameof(RestoreAlpha), duration);
	}

	private void RestoreAlpha() => SetAlpha(1);

	private void SetAlpha(float alpha)
	{
		Color color = spriteRenderer.color;

		color.a = alpha;
		spriteRenderer.color = color;
	}
}
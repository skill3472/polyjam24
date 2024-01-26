using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
	public string bossTag;
	public Image parent, sliderBackground, sliderFill;
	public TextMeshProUGUI text;
	[Min(0.01f)] public float fadeOutSpeed = 1f;

	private EntityHealth entityHealth;
	private Slider slider;

	private void Awake()
	{
		entityHealth = GameObject.FindGameObjectWithTag(bossTag).GetComponent<EntityHealth>();
		slider = GetComponent<Slider>();
	}

	private void Start() => SetSliderValues();
	private void SetSliderValues() => slider.value = slider.maxValue = entityHealth.Health;
	private void Update()
	{
		UpdateBar();
		FadeOut();
	}

	private void UpdateBar()
	{
		float a = slider.value;
		float b = entityHealth.Health;

		slider.value = Mathf.Lerp(a, b, Time.deltaTime);
	}

	private void FadeOut()
	{
		if(entityHealth.Health <= 0)
		{
			ReduceImageAlpha(parent);
			ReduceImageAlpha(sliderBackground);
			ReduceImageAlpha(sliderFill);
			ReduceTextAlpha(text);
		}
	}

	private void ReduceImageAlpha(Image image)
	{
		if(image.color.a <= 0)
		{
			return;
		}
		
		Color color = image.color;

		color.a -= AlphaReductionSpeed();

		image.color = color;
	}

	private void ReduceTextAlpha(TextMeshProUGUI text)
	{
		if(text.color.a <= 0)
		{
			return;
		}
		
		Color color = text.color;

		color.a -= AlphaReductionSpeed();

		text.color = color;
	}

	private float AlphaReductionSpeed() => Time.deltaTime*fadeOutSpeed;
}
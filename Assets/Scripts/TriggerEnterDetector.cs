using UnityEngine;

public class TriggerEnterDetector : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.TryGetComponent(out ITriggerable triggerable))
		{
			triggerable.TriggerEffect(gameObject);
		}
	}
}
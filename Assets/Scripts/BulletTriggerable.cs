using UnityEngine;

public class BulletTriggerable : MonoBehaviour, ITriggerable
{
	public void TriggerEffect(GameObject sender)
	{
		Debug.Log("Detected collision with " + sender.name);
		Destroy(gameObject);
	}
}
using UnityEngine;

public class BulletTriggerable : MonoBehaviour, ITriggerable
{
	public void TriggerEffect(GameObject sender)
	{
		Debug.Log("Detected collision with " + sender.name);
		sender.GetComponent<PlayerController>().Die(); // Temporary, plz fix later
		Destroy(gameObject);
	}
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletTriggerable : MonoBehaviour, ITriggerable
{
	public void TriggerEffect(GameObject sender)
	{
		SceneManager.LoadScene("GameOver");
	}
}
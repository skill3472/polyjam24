using UnityEngine;
using UnityEngine.SceneManagement;

public class AcidTriggerable : MonoBehaviour, ITriggerable
{
	public MusicDisabler musicDisabler;
	
	public void TriggerEffect(GameObject sender)
	{
		musicDisabler.StopMusic();
		SceneManager.LoadScene("GameOver");
	}
}
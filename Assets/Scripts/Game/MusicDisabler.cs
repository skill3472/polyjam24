using UnityEngine;

public class MusicDisabler : MonoBehaviour
{
	public void StopMusic()
	{
		GameObject mmObject = GameObject.FindGameObjectWithTag("Music Manager");

		if(mmObject.TryGetComponent(out MusicManager mm))
		{
			mm.StopMusic();
		}
	}
}
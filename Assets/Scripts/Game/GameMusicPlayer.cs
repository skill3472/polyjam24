using UnityEngine;

public class GameMusicPlayer : MonoBehaviour
{
	public AudioClip clip;

	private void Start() => PlayMusic(clip);
	
	public void PlayMusic(AudioClip clip)
	{
		GameObject mmObject = GameObject.FindGameObjectWithTag("Music Manager");

		if(mmObject.TryGetComponent(out MusicManager mm))
		{
			mm.PlayMusic(clip);
		}
	}
}
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public AudioClip clip;

	private AudioSource audioSource;

	public void PlayMusic(AudioClip clip)
	{
		audioSource.Stop();
		
		audioSource.clip = clip;
		
		audioSource.Play();
	}

	public void StopMusic() => audioSource.Stop();
	public void SetLooping(bool isLooping) => audioSource.loop = isLooping;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);

		audioSource = GetComponent<AudioSource>();
	}
	
	private void Start() => PlayMusic(clip);
}
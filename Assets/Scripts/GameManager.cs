using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager gmInstance;
	public int lastSceneIndex; // Just swap out for a normal number once the game is finished
	public int difficulty = 0;
	private AudioManager am;

	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);

		if (gmInstance == null) {
			gmInstance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	void Start()
	{
		am = FindObjectOfType<AudioManager>();
		if(SceneManager.GetActiveScene().buildIndex == lastSceneIndex)
		{
			am.Play("Win");
		}
	}
}
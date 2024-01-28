using UnityEngine;

public class DialogueTriggerable : MonoBehaviour, ITriggerable
{
	public AudioClip clip;
	public GameObject[] objectsToEnable;
	
	public void TriggerEffect(GameObject sender)
	{
		GameObject mmObject = GameObject.FindGameObjectWithTag("Music Manager");
		GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

		if(mmObject.TryGetComponent(out MusicManager mm))
		{
			mm.PlayMusic(clip);
		}

		if(playerObject.TryGetComponent(out PlayerController pc))
		{
			pc.SetAnimationsToIdle();
			
			pc.enabled = false;
		}

		foreach (GameObject go in objectsToEnable)
		{
			go.SetActive(true);
		}

		Destroy(gameObject);
	}
}
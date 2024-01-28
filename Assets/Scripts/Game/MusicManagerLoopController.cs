using UnityEngine;

public class MusicManagerLoopController : MonoBehaviour
{
	private void Start()
	{
		GameObject mmObject = GameObject.FindGameObjectWithTag("Music Manager");
		
		if(mmObject.TryGetComponent(out MusicManager mm))
		{
			mm.SetLooping(false);
		}
	}
}
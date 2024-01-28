using UnityEngine;

public class BossAwakeningTriggerable : MonoBehaviour, ITriggerable
{
	public GameObject boss;
	public GameObject player;
	public GameObject bossHealthBar;
	public CameraFollow cameraFollow;
	public PlayerController playerController;
	public BossPhaseController bossPhaseController;
	
	public void TriggerEffect(GameObject sender)
	{
		bossHealthBar.SetActive(true);
		cameraFollow.target = boss;
		bossPhaseController.enabled = true;

		Invoke(nameof(OnTriggerEnd), 5f);
	}

	private void OnTriggerEnd()
	{
		cameraFollow.target = player;
		playerController.enabled = true;
		
		Destroy(gameObject);
	}
}
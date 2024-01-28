using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ParasiteTriggerable : MonoBehaviour, ITriggerable
{
	public Collider2D c2D;
	public GameObject deathParticle;
	public UnityEvent onDeath;

	private AudioManager am;

	private void Awake() => am = FindObjectOfType<AudioManager>();
	
	public void TriggerEffect(GameObject sender)
	{
		if(sender.transform.position.y < c2D.bounds.max.y)
		{
			SceneManager.LoadScene("GameOver");
		}
		else
		{
			Instantiate(deathParticle, transform.position, Quaternion.identity);
			Destroy(gameObject);
			onDeath.Invoke();
			am.Play("ParasiteDeath");

			if(sender.TryGetComponent(out PlayerController pc))
			{
				pc.Jump();
			}
		}
	}
}
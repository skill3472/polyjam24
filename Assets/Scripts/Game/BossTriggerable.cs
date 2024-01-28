using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BossTriggerable : MonoBehaviour, ITriggerable
{
	public Collider2D c2D;
	public GameObject deathParticle;
	public UnityEvent onDeath;

	private AudioManager am;
	
	private void Awake() => am = FindObjectOfType<AudioManager>();
	
	public void TriggerEffect(GameObject sender)
	{
		if(TryGetComponent(out BossPhaseController bpc) && !bpc.IsVulnerable() && sender.transform.position.y < c2D.bounds.max.y)
		{
			SceneManager.LoadScene("GameOver");
		}
		else if(bpc.IsVulnerable() && sender.transform.position.y >= c2D.bounds.max.y)
		{
			if(sender.TryGetComponent(out PlayerController pc))
			{
				pc.JumpWithDoubledForce();
			}

			if(TryGetComponent(out EntityHealth eh))
			{
				eh.TakeDamage(1);

				if(eh.Health <= 0)
				{
					Instantiate(deathParticle, transform.position, Quaternion.identity);
					Destroy(this);
					onDeath.Invoke();
					am.Play("BossKill");
				}
				else
				{
					am.Play("BossHit");

					if(TryGetComponent(out BossRenderer br))
					{
						br.SetDamageState(2);
						DisableSelf(2);
					}
				}
			}
		}
	}

	private void DisableSelf(float duration)
	{
		c2D.enabled = false;

		Invoke(nameof(EnableSelf), duration);
	}

	private void EnableSelf() => c2D.enabled = true;
}
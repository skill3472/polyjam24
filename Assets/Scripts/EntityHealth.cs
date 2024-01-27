using UnityEngine;

public class EntityHealth : MonoBehaviour
{
	private AudioManager am;

	void Start() => am = FindObjectOfType<AudioManager>();
	public int Health
	{
		get
		{
			return health;
		}
	}
	
	[SerializeField][Range(1, 10)] private int health = 3;

	public void TakeDamage(int damage)
	{
		health -= damage;

		if(health <= 0)
		{
			Die();
			am.Play("BossKill");
		} else{
			am.Play("BossHit");
		}
	}

	public virtual void Die() => Destroy(gameObject);
	// private void Start()
	// {
	// 	InvokeRepeating(nameof(Damage), 1, 5);
	// }

	// private void Damage() => TakeDamage(1);
}
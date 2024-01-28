using UnityEngine;

public class BossBulletCollider : MonoBehaviour
{
	public Collider2D bulletCollider;
	[Min(0.01f)] public float colliderEnableDelay = 0.5f;
	
	private void Start() => Invoke(nameof(EnableCollider), colliderEnableDelay);
	private void EnableCollider() => bulletCollider.enabled = true;
	private void OnCollisionEnter2D(Collision2D other) => Deflect(other);

	private void Deflect(Collision2D other)
	{
		if(TryGetComponent(out BossBulletMovement bm))
		{
			bm.Deflect(other.GetContact(0).normal);
		}
	}
}
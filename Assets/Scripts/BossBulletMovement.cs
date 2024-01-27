using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BossBulletMovement : MonoBehaviour
{
	[Min(0.01f)] public float speed = 5f;

	private Rigidbody2D rb2D;
	private Vector3 direction;

	public void Deflect(Vector2 normal) => direction = normal;

	private void Awake() => rb2D = GetComponent<Rigidbody2D>();
	private void Start() => direction = transform.up;
	
	private void FixedUpdate()
	{
		Vector2 movement = speed*Time.fixedDeltaTime*direction;
		
		rb2D.MovePosition(rb2D.position + movement);
	}
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
	[Min(0f)] public float speed = 5f;
	public Transform startPosition, targetPosition;
	
	private Rigidbody2D rb2D;

	private void Awake() => rb2D = GetComponent<Rigidbody2D>();

	private void FixedUpdate()
	{
		if(NotReachedTarget())
		{
			MoveTowardsTarget();
		} else {
			Transform temp = startPosition;
			startPosition = targetPosition;
			targetPosition = temp;
			MoveTowardsTarget();
		}
	}

	private bool NotReachedTarget()
	{
		float distance = Vector2.Distance(gameObject.transform.position, targetPosition.position);

		return distance > Mathf.Epsilon;
	}

	private void MoveTowardsTarget()
	{
		float step = speed*Time.fixedDeltaTime;
		Vector2 direction = Vector2.MoveTowards(gameObject.transform.position, targetPosition.position, step);
		
		rb2D.MovePosition(direction);
	}
}
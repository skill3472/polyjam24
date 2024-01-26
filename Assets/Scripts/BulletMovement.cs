using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMovement : MonoBehaviour
{
	[Min(0.01f)] public float speed = 5f;
	public MovementDirection horizontalDirection = MovementDirection.NEGATIVE;
	public MovementDirection verticalDirection = MovementDirection.NONE;

	private Rigidbody2D rb2D;

	private void Awake() => rb2D = GetComponent<Rigidbody2D>();
	
	private void FixedUpdate()
	{
		Vector2 movement = speed*Time.fixedDeltaTime*MovementVector();
		
		rb2D.MovePosition(rb2D.position + movement);
	}

	private Vector2 MovementVector()
	{
		int x = DirectionValue(horizontalDirection);
		int y = DirectionValue(verticalDirection);

		return new Vector2(x, y);
	}

	private int DirectionValue(MovementDirection direction)
	{
		return direction switch
		{
			MovementDirection.NEGATIVE => -1,
			MovementDirection.NONE => 0,
			MovementDirection.POSITIVE => 1,
			_ => 0,
		};
	}
}
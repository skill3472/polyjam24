using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BossMovement : MonoBehaviour
{
	[Min(0.01f)] public float speed, upMovementRange = 1f, awakeActionsDelay = 2f, vulnerabilityDelay = 2f;

	private Vector2 direction = Vector2.zero;
	private Rigidbody2D rb2D;

	private float initialY;

	public void AwakeSelf() => StartCoroutine(nameof(OnAwakening));
	public void MakeYourselfVulnerable() => StartCoroutine(nameof(OnVulnerability));
	public void GoUp() => direction = Vector2.up;
	public void GoDown() => direction = Vector2.down;

	public IEnumerator OnAwakening()
	{
		GoUp();

		yield return new WaitForSeconds(awakeActionsDelay);

		GoDown();

		yield return new WaitForSeconds(awakeActionsDelay);

		if(TryGetComponent(out BossPhaseController bpc))
		{
			bpc.StartExecutingActions();
		}
	}

	private void Awake() => rb2D = GetComponent<Rigidbody2D>();
	private void Start() => initialY = rb2D.position.y;

	private IEnumerator OnVulnerability()
	{
		GoUp();

		yield return new WaitForSeconds(vulnerabilityDelay);

		GoDown();
	}

	private void FixedUpdate()
	{
		float step = speed*Time.fixedDeltaTime;
		Vector2 movement = step*direction;

		if(PositionDoesNotExceedRange())
		{
			rb2D.MovePosition(rb2D.position + movement);
		}
	}

	private bool PositionDoesNotExceedRange()
	{
		bool exceedsMin = direction == Vector2.down && rb2D.position.y < initialY;
		bool exceedsMax = direction == Vector2.up && rb2D.position.y > initialY + upMovementRange;

		return !exceedsMin && !exceedsMax;
	}
}
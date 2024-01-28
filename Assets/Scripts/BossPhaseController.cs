using UnityEngine;
using System.Collections;

public class BossPhaseController : MonoBehaviour
{
	public BossAction[] actions;

	private BossPhase currentPhase;
	private int currentActionIndex = 0;

	public void StartExecutingActions() => StartCoroutine(nameof(ExecuteActions));

	public bool IsVulnerable() => currentPhase == BossPhase.VULNERABILITY;

	public void SetState(BossPhase newPhase)
	{
		currentPhase = newPhase;

		OnStateChange();
	}

	private void Start() => SetState(BossPhase.AWAKENING);

	private IEnumerator ExecuteActions()
	{
		while (true)
		{
			BossAction currentAction = actions[currentActionIndex];

			currentActionIndex = (currentActionIndex + 1) % actions.Length;

			SetState(currentAction.phase);

			yield return new WaitForSeconds(currentAction.delay);
		}
	}

	private void OnStateChange()
	{
		switch (currentPhase)
		{
			case BossPhase.AWAKENING:
				OnAwakening();
				break;

			case BossPhase.SHOOT:
				OnShoot();
				break;

			case BossPhase.VULNERABILITY:
				OnVulnerability();
				break;

			case BossPhase.DEATH:
				OnDeath();
				break;
		}
	}

	private void OnAwakening()
	{
		if(TryGetComponent(out BossMovement bm))
		{
			bm.AwakeSelf();
		}
	}

	private void OnShoot()
	{
		if(TryGetComponent(out BossShoot bs))
		{
			bs.Shoot();
		}
	}

	private void OnVulnerability()
	{
		if(TryGetComponent(out BossMovement bm))
		{
			bm.MakeYourselfVulnerable();
		}
	}
	
	private void OnDeath()
	{
		// play death animation and play sound
		
		Debug.Log("death");
	}
}

[System.Serializable]
public class BossAction
{
	public BossPhase phase;
	[Min(0f)] public float delay;
}
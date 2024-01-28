using UnityEngine;

public class BossHealth : EntityHealth
{
	public override void Die()
	{
		if(TryGetComponent(out Animator animator))
		{
			animator.SetBool("Dead", true);
		}

		if(TryGetComponent(out BossPhaseController bpc))
		{
			Destroy(bpc);
		}

		if(TryGetComponent(out BossRenderer br))
		{
			Destroy(br);
		}
	}
}
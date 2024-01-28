using UnityEngine;
using System.Collections;

public class BossShoot : MonoBehaviour
{
	[Min(1)] public int bulletsPerAction;
	public GameObject bullet;
	[Min(0.01f)] public float shootDelay = 0.01f;
	public Transform firePoint;

	private AudioManager am;

	private void Awake() => am = FindObjectOfType<AudioManager>();

	public void Shoot()
	{
		StartCoroutine(nameof(OnShoot));
	}

	private IEnumerator OnShoot()
	{
		for (int i = 0; i < bulletsPerAction; ++i)
		{
			float division = i / (float)(bulletsPerAction - 1);
			float angle = -15f + 90f*division;

			Instantiate(bullet, firePoint.position, Quaternion.Euler(Vector3.forward*angle));
			am.Play("BossShoot");

			yield return new WaitForSeconds(shootDelay);
		}
	}
}
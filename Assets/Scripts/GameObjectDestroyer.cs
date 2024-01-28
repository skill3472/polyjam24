using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
	[Min(0.01f)] public float delay = 1f;

	private void Start() => Destroy(gameObject, delay);
}
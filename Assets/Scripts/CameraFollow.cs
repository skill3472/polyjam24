using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	[Min(0.01f)] public float speed = 2f;
	public float minY, maxY;

    void Start() => target = GameObject.Find("Player");

	private void LateUpdate()
	{
		Vector3 cameraPosition = Camera.main.transform.position;
		Vector2 lerpedPosition = Vector2.Lerp(cameraPosition, target.transform.position, Time.deltaTime*speed);
		float y = Mathf.Clamp(lerpedPosition.y, minY, maxY);

		transform.position = new Vector3(cameraPosition.x, y, cameraPosition.z);
	}
}
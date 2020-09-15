using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	private void Update()
	{
		if (transform.position.x < -24)
		{
			Destroy(gameObject);
		}
	}
}

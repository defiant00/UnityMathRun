using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.gameObject.GetComponent<PlayerController>();
		if (player != null) Debug.Log("Is player!");
	}

	private void Update()
	{
		if (transform.position.x < -8)
		{
			Destroy(gameObject);
		}
	}
}

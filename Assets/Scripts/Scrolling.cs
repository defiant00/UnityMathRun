using UnityEngine;

public class Scrolling : MonoBehaviour
{
	public float moveMult = 1;

	void FixedUpdate()
	{
		transform.position = new Vector3(transform.position.x - moveMult * Time.fixedDeltaTime * GameState.scrollSpeed, transform.position.y, transform.position.z);
	}
}

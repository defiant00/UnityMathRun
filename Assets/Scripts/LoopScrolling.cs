using UnityEngine;

public class LoopScrolling : MonoBehaviour
{
	private float width, minX;

	void Start()
	{
		width = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		minX = -(width + 8);
	}

	void Update()
	{
		while (transform.position.x < minX)
		{
			transform.position = new Vector3(transform.position.x + width, transform.position.y, transform.position.z);
		}
	}
}

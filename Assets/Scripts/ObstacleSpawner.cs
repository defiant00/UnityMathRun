using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public GameObject[] obstacle;

	float interval = 2;
	float counter = 0;

	void FixedUpdate()
	{
		counter -= Time.fixedDeltaTime * GameState.scrollSpeed;
		while (counter < 0)
		{
			counter += interval;
			Instantiate(obstacle[0], new Vector3(8, Random.Range(-3f, 3f), 0), Quaternion.identity).transform.parent = transform;
		}
	}
}

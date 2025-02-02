﻿using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	public GameObject[] obstacles;
	public float[] widths;

	public GameObject problem;
	public float problemWidth = 8;

	float counter = 2 * GameState.runningSpeed;
	int spawnCount = 0;
	const int PROBLEM_INTERVAL = 5;
	const int NUM_PROBLEMS_DIFFICULTY_INCREASE = 4;

	void FixedUpdate()
	{
		counter -= Time.fixedDeltaTime * GameState.scrollSpeed;
		while (counter < 0)
		{
			spawnCount++;
			if (spawnCount % PROBLEM_INTERVAL == 0)
			{
				GameState.problemCount++;
				counter += Random.Range(problemWidth, problemWidth + 2);
				Instantiate(problem, transform).transform.localPosition = new Vector3(8, 0, 0);
			}
			else
			{
				int id = Random.Range(0, Mathf.Min((GameState.problemCount / NUM_PROBLEMS_DIFFICULTY_INCREASE) + 1, obstacles.Length));
				counter += Random.Range(widths[id] + GameState.runningSpeed - 1, widths[id] + GameState.runningSpeed + 2);
				Instantiate(obstacles[id], transform).transform.localPosition = new Vector3(8, 0, 0);
			}
		}
	}
}

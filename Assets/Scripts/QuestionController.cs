using UnityEngine;

public class QuestionController : MonoBehaviour
{
	private GameObject wall;

	private void Start()
	{
		wall = transform.Find("Wall").gameObject;
	}

	public void Answer(int choice)
	{
		if (choice == 1)
		{
			Destroy(wall);
		}
		else
		{
			GameState.State = GameState.CurrentGameState.Tripped;
		}
	}
}

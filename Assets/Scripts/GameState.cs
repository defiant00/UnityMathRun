using UnityEngine;

public class GameState : MonoBehaviour
{
	public enum CurrentGameState
	{
		Running,
		Problem,
		Tripped,
		Done,
	}

	const float NORMAL_SCROLL_SPEED = 5;
	const float PROBLEM_SCROLL_SPEED = 0.5f;
	const float TRIPPED_SCROLL_SPEED = 1;

	const float PROBLEM_TIMER = 4;
	const float TRIPPED_TIMER = 2;

	public static float scrollSpeed = NORMAL_SCROLL_SPEED;
	public static int problemCount = 0;
	public static decimal totalDistance = 0;

	private static CurrentGameState _state = CurrentGameState.Running;
	public static CurrentGameState State
	{
		get => _state;
		set
		{
			if (_state != value)
			{
				_state = value;
				switch (_state)
				{
					case CurrentGameState.Running:
						scrollSpeed = NORMAL_SCROLL_SPEED;
						break;
					case CurrentGameState.Problem:
						scrollSpeed = PROBLEM_SCROLL_SPEED;
						timer = PROBLEM_TIMER;
						break;
					case CurrentGameState.Tripped:
						scrollSpeed = TRIPPED_SCROLL_SPEED;
						timer = TRIPPED_TIMER;
						break;
					case CurrentGameState.Done:
						scrollSpeed = 0;
						break;
				}
			}
		}
	}

	public static bool Active => State == CurrentGameState.Running || State == CurrentGameState.Problem;

	private static float timer = 0;

	void Start()
	{
		scrollSpeed = NORMAL_SCROLL_SPEED;
		problemCount = 0;
		totalDistance = 0;
		State = CurrentGameState.Running;
	}

	void Update()
	{
		totalDistance += (decimal)(Time.deltaTime * scrollSpeed);

		if (timer > 0)
		{
			timer -= Time.deltaTime;
			if (timer < 0)
			{
				if (State == CurrentGameState.Problem) State = CurrentGameState.Running;
				else if (State == CurrentGameState.Tripped) State = CurrentGameState.Done;
			}
		}
	}
}

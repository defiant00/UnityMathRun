using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
	private GameObject wall;
	private ProblemData data;
	private int correctChoice;
	private bool answered = false;

	private TextMeshProUGUI questionText, answer1Text, answer2Text;

	private void Start()
	{
		wall = transform.Find("Wall").gameObject;
		data = GameState.problem.GetProblem();
		correctChoice = Random.Range(1, 3);
		questionText = transform.Find("Canvas/Question").GetComponent<TextMeshProUGUI>();
		answer1Text = transform.Find("Canvas/Answer 1").GetComponent<TextMeshProUGUI>();
		answer2Text = transform.Find("Canvas/Answer 2").GetComponent<TextMeshProUGUI>();
		questionText.text = data.Question;
		answer1Text.text = correctChoice == 1 ? data.Correct : data.Wrong;
		answer2Text.text = correctChoice == 1 ? data.Wrong : data.Correct;
	}

	public void Answer(int choice)
	{
		if (!answered)
		{
			answered = true;
			if (choice == correctChoice)
			{
				Destroy(wall);
			}
			else
			{
				GameState.State = GameState.CurrentGameState.Tripped;
			}
		}
	}
}

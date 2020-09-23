using TMPro;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
	public TextMeshProUGUI questionText, answer1Text, answer2Text;
	public GameObject wall;
	public Sprite correctSprite, wrongSprite;
	public ParticleSystem correctParticles;
	public ParticleSystem[] waspParticles;

	private ProblemData data;
	private int correctChoice;
	private bool answered = false;

	private void Start()
	{
		data = GameState.problemGenerator.GetProblem();
		correctChoice = Random.Range(1, 3);
		questionText.text = data.Question;
		answer1Text.text = correctChoice == 1 ? data.Correct : data.Wrong;
		answer2Text.text = correctChoice == 1 ? data.Wrong : data.Correct;
	}

	public void Answer(int choice, SpriteRenderer renderer)
	{
		if (!answered)
		{
			answered = true;
			if (choice == correctChoice)
			{
				renderer.sprite = correctSprite;
				Destroy(wall);
				var lp = correctParticles.transform.localPosition;
				correctParticles.transform.localPosition = new Vector3(choice == 1 ? 5 : 9, lp.y, lp.z);
				correctParticles.Play();
				foreach (var p in waspParticles)
				{
					p.Play();
				}
			}
			else
			{
				renderer.sprite = wrongSprite;
				GameState.State = GameState.CurrentGameState.Tripped;
			}
		}
	}
}

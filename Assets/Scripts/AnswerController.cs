using UnityEngine;

public class AnswerController : MonoBehaviour
{
	private QuestionController questionController;

	private void Start()
	{
		questionController = GetComponentInParent<QuestionController>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		questionController.Answer(name == "AnswerBox1" ? 1 : 2);
	}
}

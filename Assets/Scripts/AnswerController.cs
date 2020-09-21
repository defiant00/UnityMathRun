using UnityEngine;

public class AnswerController : MonoBehaviour
{
	private QuestionController questionController;
	private SpriteRenderer _renderer;

	private void Start()
	{
		questionController = GetComponentInParent<QuestionController>();
		_renderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		questionController.Answer(name == "AnswerBox1" ? 1 : 2, _renderer);
	}
}

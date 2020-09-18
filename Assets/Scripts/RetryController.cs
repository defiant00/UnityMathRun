using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
	public TextMeshProUGUI yesText, noText;

	private bool yes = true;
	private float priorH = 0;

	void Start() => UpdateText();

	void Update()
	{
		float h = Input.GetAxis("Horizontal");

		if (h <= -0.5f && priorH > -0.5f)
		{
			yes = true;
			UpdateText();
		}
		else if (h >= 0.5f && priorH < 0.5f)
		{
			yes = false;
			UpdateText();
		}

		priorH = h;

		if (Input.GetButtonDown("Jump"))
		{
			SceneManager.LoadScene(yes ? "Game" : "Menu");
		}
	}

	void UpdateText()
	{
		yesText.color = yes ? Color.yellow : Color.white;
		noText.color = yes ? Color.white : Color.yellow;
	}
}

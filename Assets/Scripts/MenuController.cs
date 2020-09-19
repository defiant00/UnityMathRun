using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public TextMeshProUGUI problemText, speedText, quitText;

	private readonly string[] problemMenuVals = { "Addition (easy)", "Addition (hard)", "Subtraction (easy)", "Subtraction (hard)", "Multiplication", "Division", "Recognize Multiples", "Compare Numbers", "Prime Numbers", "All" };
	private readonly string[] speedMenuVals = { "Slow", "Normal", "Fast" };

	private const int MENU_ITEM_COUNT = 3;
	private int menuIndex = 0;

	private float priorH = 0;
	private float priorV = 0;

	void Start() => UpdateText();

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (h <= -0.5f && priorH > -0.5f)
		{
			if (menuIndex == 0)
			{
				GameState.problemIndex--;
				if (GameState.problemIndex < 0)
				{
					GameState.problemIndex += problemMenuVals.Length;
				}
			}
			else if (menuIndex == 1)
			{
				GameState.speedIndex--;
				if (GameState.speedIndex < 0)
				{
					GameState.speedIndex += speedMenuVals.Length;
				}
			}
			UpdateText();
		}
		else if (h >= 0.5f && priorH < 0.5f)
		{
			if (menuIndex == 0)
			{
				GameState.problemIndex = (GameState.problemIndex + 1) % problemMenuVals.Length;
			}
			else if (menuIndex == 1)
			{
				GameState.speedIndex = (GameState.speedIndex + 1) % speedMenuVals.Length;
			}
			UpdateText();
		}

		if (v <= -0.5f && priorV > -0.5f)
		{
			menuIndex = (menuIndex + 1) % MENU_ITEM_COUNT;
			UpdateText();
		}
		else if (v >= 0.5f && priorV < 0.5f)
		{
			menuIndex--;
			if (menuIndex < 0)
			{
				menuIndex += MENU_ITEM_COUNT;
			}
			UpdateText();
		}

		priorH = h;
		priorV = v;

		if (Input.GetButtonDown("Jump"))
		{
			if (menuIndex == 2)
			{
				Application.Quit();
			}
			else
			{
				// Set problems
				switch (GameState.problemIndex)
				{
					case 0:
						GameState.problemGenerator = new Addition1();
						break;
					case 1:
						GameState.problemGenerator = new Addition2();
						break;
					case 2:
						GameState.problemGenerator = new Subtraction1();
						break;
					case 3:
						GameState.problemGenerator = new Subtraction2();
						break;
					case 4:
						GameState.problemGenerator = new Multiplication1();
						break;
					case 5:
						GameState.problemGenerator = new Division1();
						break;
					case 6:
						GameState.problemGenerator = new Multiple1();
						break;
					case 7:
						GameState.problemGenerator = new Comparison1();
						break;
					case 8:
						GameState.problemGenerator = new Primes1();
						break;
					case 9:
						GameState.problemGenerator = new AllProblems();
						break;
				}

				// Set speed
				float[] speeds = { GameState.SLOW_SCROLL_SPEED, GameState.NORMAL_SCROLL_SPEED, GameState.FAST_SCROLL_SPEED };
				GameState.runningSpeed = speeds[GameState.speedIndex];

				SceneManager.LoadScene("Game");
			}
		}
	}

	void UpdateText()
	{
		problemText.text = problemMenuVals[GameState.problemIndex];
		speedText.text = speedMenuVals[GameState.speedIndex];

		problemText.color = (menuIndex == 0) ? Color.yellow : Color.white;
		speedText.color = (menuIndex == 1) ? Color.yellow : Color.white;
		quitText.color = (menuIndex == 2) ? Color.yellow : Color.white;
	}
}

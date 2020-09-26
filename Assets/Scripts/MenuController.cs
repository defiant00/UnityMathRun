using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public TextMeshProUGUI playText, problemText, speedText, quitText;

	private readonly string[] problemMenuVals = { "Addition (easy)", "Addition (hard)", "Subtraction (easy)", "Subtraction (hard)", "Multiplication", "Division", "Recognize Multiples", "Compare Numbers", "Prime Numbers", "All" };
	private readonly string[] speedMenuVals = { "Slow", "Normal", "Fast" };

	private const int MENU_ITEM_COUNT = 4;
	private int menuIndex = 0;

	private float priorH = 0;
	private float priorV = 0;

	private RandomSound sound;

	void Start()
	{
		sound = GetComponent<RandomSound>();
		UpdateText();
	}

	void Update()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		if (h <= -0.5f && priorH > -0.5f)
		{
			if (menuIndex == 1)
			{
				sound.PlayRandomSound();
				GameState.problemIndex--;
				if (GameState.problemIndex < 0)
				{
					GameState.problemIndex += problemMenuVals.Length;
				}
			}
			else if (menuIndex == 2)
			{
				sound.PlayRandomSound();
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
			if (menuIndex == 1)
			{
				sound.PlayRandomSound();
				GameState.problemIndex = (GameState.problemIndex + 1) % problemMenuVals.Length;
			}
			else if (menuIndex == 2)
			{
				sound.PlayRandomSound();
				GameState.speedIndex = (GameState.speedIndex + 1) % speedMenuVals.Length;
			}
			UpdateText();
		}

		if (v <= -0.5f && priorV > -0.5f)
		{
			sound.PlayRandomSound();
			menuIndex = (menuIndex + 1) % MENU_ITEM_COUNT;
			UpdateText();
		}
		else if (v >= 0.5f && priorV < 0.5f)
		{
			sound.PlayRandomSound();
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
			if (menuIndex == 3)
			{
				Application.Quit();
			}
			else if (menuIndex == 0)
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

		playText.color = (menuIndex == 0) ? Color.yellow : Color.white;
		problemText.color = (menuIndex == 1) ? Color.yellow : Color.white;
		speedText.color = (menuIndex == 2) ? Color.yellow : Color.white;
		quitText.color = (menuIndex == 3) ? Color.yellow : Color.white;
	}
}

using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
	private TextMeshProUGUI score;

	void Start()
	{
		score = GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{
		score.text = GameState.totalDistance.ToString("N2");
	}
}

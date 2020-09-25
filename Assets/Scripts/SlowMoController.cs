using UnityEngine;

public class SlowMoController : MonoBehaviour
{
	private bool armed = true;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.gameObject.GetComponent<PlayerController>();
		if (player != null && GameState.Active && armed)
		{
			armed = false;
			player.PlayShockedSound();
			GameState.State = GameState.CurrentGameState.Problem;
		}
	}
}

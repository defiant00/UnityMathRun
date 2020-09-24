using UnityEngine;

public class SlowMoController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.gameObject.GetComponent<PlayerController>();
		if (player != null)
		{
			player.PlayShockedSound();
			GameState.State = GameState.CurrentGameState.Problem;
		}
	}
}

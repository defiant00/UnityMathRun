using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.gameObject.GetComponent<PlayerController>();
		if (player != null && GameState.Active)
		{
			player.PlayTrippedSound();
			GameState.State = GameState.CurrentGameState.Tripped;
		}
	}
}

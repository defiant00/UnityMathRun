using UnityEngine;

public class SimpleAnimation : MonoBehaviour
{
	public Sprite[] sprites;
	public float frameTiming = 0.1f;
	public bool randomStart = true;

	private SpriteRenderer _renderer;
	private float counter;
	private int spriteIndex;

	void Start()
	{
		_renderer = GetComponent<SpriteRenderer>();
		counter = randomStart ? Random.Range(0, frameTiming) : frameTiming;
		spriteIndex = randomStart ? Random.Range(0, sprites.Length) : 0;
	}

	void Update()
	{
		counter -= Time.deltaTime;
		while (counter < 0)
		{
			counter += frameTiming;
			spriteIndex = (spriteIndex + 1) % sprites.Length;
			_renderer.sprite = sprites[spriteIndex];
		}
	}
}

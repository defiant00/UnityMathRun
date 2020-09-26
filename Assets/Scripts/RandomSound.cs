using UnityEngine;

public class RandomSound : MonoBehaviour
{
	public AudioClip[] sounds;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayRandomSound() => audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
}

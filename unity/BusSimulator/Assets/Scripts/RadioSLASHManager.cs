using UnityEngine;
using System.Collections;

public class RadioSLASHManager : MonoBehaviour
{
	private AudioSource player;
	public AudioClip song1;
	public AudioClip song2;
	public AudioClip song3;
	private Queue playlist;
	private 

	// Use this for initialization
	void Start ()
	{
		player = gameObject.AddComponent<AudioSource> ();
		load ();
		player.clip = collideAndEnque ();
		player.volume = 50;
	}
	void load ()
	{
		playlist = new Queue ();
		playlist.Enqueue (null);
		playlist.Enqueue (song1);
		playlist.Enqueue (song2);
		playlist.Enqueue (song3);
	}

	AudioClip collideAndEnque ()
	{
		AudioClip buffer = (AudioClip)playlist.Dequeue ();
		playlist.Enqueue (buffer);
		return buffer;
	}

	public void nextS ()
	{	
		player.clip = collideAndEnque ();

		player.Play ();
	}
}

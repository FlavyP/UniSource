using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

	private GameObject pauseUI;
	private bool paused;
	private Shooter shooterScript;

	// Use this for initialization
	void Start ()
	{
		pauseUI = GameObject.Find ("PausePanel");
		paused = false;
		pauseUI.SetActive (false);
		shooterScript = GameObject.Find ("Car").GetComponent<Shooter> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
			shooterScript.enabled = !shooterScript.enabled;
		}

		if (paused) {
			pauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		if (!paused) {
			pauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume ()
	{
		paused = false;
		shooterScript.enabled = true;
	}
}

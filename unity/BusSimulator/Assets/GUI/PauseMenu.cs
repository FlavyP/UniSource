using UnityEngine;
using System.Collections;


	/*
	 * Author: Arnas
	 */

public class PauseMenu : MonoBehaviour
{
	private GameObject pauseUI;
	private bool paused;

	public INPUT inputScript;
	public MENU_INPUT menuInputScript;

	// Use this for initialization
	void Start ()
	{
		pauseUI = GameObject.Find ("PausePanel");
		paused = false;
		pauseUI.SetActive (false);

		inputScript.changeStatus(false);
		menuInputScript.changeStatus(true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (paused) {
			pauseUI.SetActive (true);
			Time.timeScale = 0;
			inputScript.changeStatus(false);
			menuInputScript.changeStatus(true);
		} else if (!paused) {
			pauseUI.SetActive (false);
			Time.timeScale = 1;
			menuInputScript.changeStatus(false);
			inputScript.changeStatus(true);
		}
	}

	public void Resume ()
	{
		paused = false;
	}


	public void Pause ()
	{
		paused = true;
	}

	public bool isPaused(){
		return paused;
	}
}

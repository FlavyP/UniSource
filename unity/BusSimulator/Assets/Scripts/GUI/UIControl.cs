using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{

	/**
	 * Author: Flavian Popa
	 * 
	 **/

	public Slider backgroundSlider;
	private AudioSource backgroundMusic;
	private GameObject currentValue;
	private int curVol;

	void Awake ()
	{
		currentValue = GameObject.Find ("currentValue");
		curVol = 0;
		if (GameObject.Find ("BackgroundMusic") != null) {
			backgroundMusic = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
			backgroundMusic.volume = PlayerPrefs.GetFloat ("CurrentVolume");
		}
		if (backgroundSlider) {
			backgroundSlider.value = backgroundMusic.volume;
			curVol = Mathf.RoundToInt (backgroundMusic.volume * 100);
		}
		if (currentValue) {
			currentValue.GetComponent<Text> ().text = curVol.ToString ();
		}
	}

	public void changeScene (int sceneID)
	{
		//Modify sceneID with PlayGame ID
		/*if(sceneID == 2)
		{
			Destroy (GameObject.Find ("BackgroundMusic"));
		}*/

		//SceneID of second level
		if (sceneID == 6) {
			PlayerPrefs.SetInt ("Deliveries", 3);
			PlayerPrefs.SetFloat ("Timer", 300.0f);
		} else if (sceneID == 7) {
			PlayerPrefs.SetInt ("Deliveries", 5);
			PlayerPrefs.SetFloat ("Timer", 500.0f);
		} 

		SceneManager.LoadScene (sceneID);
	}


	public void volumeControl (float volume)
	{
		backgroundMusic.volume = volume;
		curVol = Mathf.RoundToInt (backgroundMusic.volume * 100);
		currentValue.GetComponent<Text> ().text = curVol.ToString ();
		PlayerPrefs.SetFloat ("CurrentVolume", backgroundMusic.volume);
	}

	public void increaseSound ()
	{
		backgroundMusic.volume = backgroundMusic.volume + 0.05f;
		backgroundSlider.value = backgroundMusic.volume;
		curVol = Mathf.RoundToInt (backgroundMusic.volume * 100);
		currentValue.GetComponent<Text> ().text = curVol.ToString ();
		PlayerPrefs.SetFloat ("CurrentVolume", backgroundMusic.volume);
	}

	public void decreaseSound ()
	{
		backgroundMusic.volume = backgroundMusic.volume - 0.05f;
		backgroundSlider.value = backgroundMusic.volume;
		curVol = Mathf.RoundToInt (backgroundMusic.volume * 100);
		currentValue.GetComponent<Text> ().text = curVol.ToString ();
		PlayerPrefs.SetFloat ("CurrentVolume", backgroundMusic.volume);
	}

	public void quitGame ()
	{
		UnityEditor.EditorApplication.isPlaying = false;
	}
}

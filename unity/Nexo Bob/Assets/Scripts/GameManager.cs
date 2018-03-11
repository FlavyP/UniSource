using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

	/*
    * Author: Arnas Kromelis
    * Description: GameManager
    * Version: v1.1
    */

	public GameObject BattleOverScreen;
	public GameObject StoryScreen;
	public GameObject loadingPanel;
	public GameObject starPanel;
	public BattleManager battleManager;

	private Image spinnerImage;
	private string scene;
	private bool ScanTargetsEnabled = false;
	private bool StoryIsActive = false;
	private bool BattleIsActive = false;

	void Start ()
	{
		checkIfStoryNeedsToBeShown ();

		if (loadingPanel != null) {
			loadingPanel.SetActive (false);
			spinnerImage = findChild (loadingPanel, "Spinner").GetComponent<Image> ();
		}

		if (StoryScreen != null) {
			StoryScreen.SetActive (StoryIsActive);
			if (StoryIsActive) {
				ScanTargetsEnabled = true;
			}
		}

		if (BattleOverScreen != null) {
			BattleOverScreen.SetActive (false);
		}

	}

	private void checkIfStoryNeedsToBeShown ()
	{

		Debug.Log ("Scene name: " + SceneManager.GetActiveScene ().name);

		// Check if user has read the instructions
		if (PlayerPrefs.GetString ("ReadInstruction", "false") == "false" && SceneManager.GetActiveScene ().name == "World Map") {
			StoryIsActive = true;
			PlayerPrefs.SetString ("ReadInstruction", "true");
		}

		// Check if user has read the introduction
		if (PlayerPrefs.GetString ("ReadIntro", "false") == "false" && SceneManager.GetActiveScene ().name == "HeroScan") {
			StoryIsActive = true;
			PlayerPrefs.SetString ("ReadIntro", "true");
		} else {
			ScanTargetsEnabled = true;
		}

		// Forest level 
		if (SceneManager.GetActiveScene ().name == "Forest") {
			StoryIsActive = true;
		}
	}

	void Update ()
	{
		if (loadingPanel != null && loadingPanel.activeSelf) {
			// Spinner image for loading screen
			spinnerImage.color = new Color (spinnerImage.color.r, spinnerImage.color.g, spinnerImage.color.b, Mathf.PingPong (Time.time, 1));
			spinnerImage.transform.Rotate (-Vector3.forward * Time.deltaTime * 200f, Space.World);
		}

		if (BattleIsActive && battleManager.isBattleFinished ()) {
			BattleIsActive = false;
			BattleOverScreen.SetActive (true);

			Text top = GameObject.Find ("top").GetComponent<Text> ();
			Text story = GameObject.Find ("story").GetComponent<Text> ();

			bool playerWon = battleManager.getPlayerWon ();
			if (playerWon) {
				top.text = "GOOD JOB";
				story.text = "You encouraged the enemy to give up and they lost their will to fight. The enemy is now your friend!";
			} else {
				top.text = "UNFORTUNATE";
				story.text = "This time your enemy was stronger. Don't loose hope, we know you can be victorious next time!";
			}
			updateStarPanel ();
		}

		if (BattleIsActive && battleManager.waitingForInputTextLabel != null && battleManager.waitingForInputTextLabel.gameObject.activeSelf) {
			ScanTargetsEnabled = true;
		}

	}

	// Start/Opening screen
	public void loadShieldScanning ()
	{
		StoryScreen.SetActive (false);
		ScanTargetsEnabled = true;
	}

	// Enabl story screen
	public void loadStory ()
	{
		loadStory (true);
	}

	// Enable/disable story screen
	public void loadStory (bool status)
	{
		if (status) {
			if (BattleOverScreen != null) {
				BattleOverScreen.SetActive (false);
			}
        
			StoryScreen.SetActive (true);
		} else {
			StoryScreen.SetActive (false);

			if (battleManager != null) {
				battleManager.startBattle ();
				BattleIsActive = true;
			}

		}

	}

	// Load scene by scene build number
	public void loadScene (int sceneNumber)
	{
		loadLevel (SceneManager.GetSceneAt (sceneNumber).name);
	}

	// Load scene by scene name
	public void loadLevel (string levelName)
	{

		string textToSet = "";

		switch (levelName) {
		case "Rewards":
			textToSet = "Preparing rewards!";
			break;
		case "World Map":
			if (SceneManager.GetActiveScene ().name == "HeroScan") {
				textToSet = "Success!";
			} else {
				textToSet = "Preparing the map!";
			}
			break;
		case "Forest":
		case "WaterfallMountain":
		case "LavaMountain":
			textToSet = "Prepare your cards!";
			break;
		default:
			textToSet = "";
			break;
		}

		findChild (loadingPanel, "top").GetComponent<Text> ().text = textToSet;

		loadingPanel.SetActive (true);
		scene = levelName;

		StartCoroutine (loadNewScene ());
	}

	// Exit Game
	public void quitGame ()
	{
		Application.Quit ();
	}


	// Start loading new scene in async
	IEnumerator loadNewScene ()
	{
        
		AsyncOperation async = SceneManager.LoadSceneAsync (scene);

		while (!async.isDone) {
			yield return null;
		}

	}

	// Method to find a child by name in the parent object
	public static Transform findChild (GameObject parent, string childName)
	{
		foreach (Transform child in parent.transform) {
			if (child.name == childName) {
				return child;
			}
		}

		Debug.Log ("not found");

		return null;
	}

	public bool CanScanTargets ()
	{
		return ScanTargetsEnabled;
	}

	public void CanScanTargets (bool status)
	{
		ScanTargetsEnabled = status;
	}

	public void updateStarPanel ()
	{
		Transform star1 = findChild (starPanel, "Star1");
		Transform star2 = findChild (starPanel, "Star2");
		Transform star3 = findChild (starPanel, "Star3");
		Transform star4 = findChild (starPanel, "Star4");
		Transform star5 = findChild (starPanel, "Star5");


		int stars = battleManager.getStars ();
		Debug.Log ("Stars: " + stars);
		Debug.Log (star1.name);

		switch (stars) {
		case 1:
			star1.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star2.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			star3.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			star4.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			star5.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			break;
		case 2:
			star1.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star3.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			star4.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			star5.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			break;
		case 3:
			star1.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star3.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star4.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			star5.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			break;
		case 4:
			star1.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star3.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star4.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star5.GetComponent<Image> ().color = new Color32 (118, 118, 118, 255);
			break;
		case 5:
			star1.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star2.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star3.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star4.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			star5.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
			break;
		}
	}
}

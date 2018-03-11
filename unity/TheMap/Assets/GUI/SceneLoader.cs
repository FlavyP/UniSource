using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

	void Update () {
		checkIfAllEnemiesDestroyed ();
	}

	private void checkIfAllEnemiesDestroyed() {
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			switch (SceneManager.GetActiveScene ().name) {
			case "Scene2":
				changeScene ("destroyed_city");
				break;
			case "destroyed_city":
				changeScene ("YouWin");
				break;
			default:
				break;
			}
		}
	}

	public void changeScene (string sceneName)
	{
		Application.LoadLevel (sceneName);
	}

	public void quitGame ()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
		#else
			Application.Quit ();
		#endif
	}
}

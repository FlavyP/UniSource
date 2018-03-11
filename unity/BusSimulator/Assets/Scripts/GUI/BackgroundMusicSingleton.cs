using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackgroundMusicSingleton : MonoBehaviour {

	/**
	 * Author: Flavian Popa
	 * 
	 **/

	private static BackgroundMusicSingleton instance;

	public static BackgroundMusicSingleton GetInstance()
	{
		return instance;
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
	}
}

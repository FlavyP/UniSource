using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadPrefs : MonoBehaviour {

	public Text hero;

	// Use this for initialization
	void Start () {
		hero.text = PlayerPrefs.GetString("Hero", "Clay");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class winScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text text = GetComponent<Text>();
        int i = PlayerPrefs.GetInt("Highscore", 0);
        i = i + 10;
        text.text = i.ToString();
        PlayerPrefs.SetInt("Highscore", i);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

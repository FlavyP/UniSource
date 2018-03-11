using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class loadScore : MonoBehaviour {
    private float score;
    private Text text;
    // Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

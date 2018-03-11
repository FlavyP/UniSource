using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Soundsetter : MonoBehaviour {
    private Slider s1;
	// Use this for initialization
	void Start () {
        s1 = GetComponent<Slider>();
        s1.value = PlayerPrefs.GetFloat ("Background", 1);
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetFloat("Background", s1.value);
    }
}

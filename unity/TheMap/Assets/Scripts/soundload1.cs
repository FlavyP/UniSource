using UnityEngine;
using System.Collections;

public class soundload1 : MonoBehaviour {
    private AudioSource a1;
	// Use this for initialization
	void Start () {
        a1 = GetComponent<AudioSource>();
        a1.volume = PlayerPrefs.GetFloat("Background", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

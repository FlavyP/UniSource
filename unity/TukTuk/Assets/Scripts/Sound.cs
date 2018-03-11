using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
    private AudioSource s1;
    // Use this for initialization
    void Start () {
        s1 = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Sound"))
            s1.volume = PlayerPrefs.GetFloat("Sound", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

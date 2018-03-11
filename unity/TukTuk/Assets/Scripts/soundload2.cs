using UnityEngine;
using System.Collections;

public class soundload2 : MonoBehaviour {

    private AudioSource a1;
    // Use this for initialization
    void Start()
    {
        a1 = GetComponent<AudioSource>();
        a1.volume = PlayerPrefs.GetFloat("fx", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

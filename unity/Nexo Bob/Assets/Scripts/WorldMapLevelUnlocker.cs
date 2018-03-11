using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class WorldMapLevelUnlocker : MonoBehaviour {

    // Use this for initialization
    void Start () {
        int level = PlayerPrefs.GetInt("LevelCompleted");
        if(level == 2)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}

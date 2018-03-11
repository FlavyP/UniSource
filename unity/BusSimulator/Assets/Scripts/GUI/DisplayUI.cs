using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DisplayUI : MonoBehaviour
{
	/**
	 * Author: Flavian Popa
	 * 
	 **/

	public Text levelHoverText;

	// Use this for initialization
	void Start ()
	{
		//level1HoverText = GameObject.Find ("level1Hover").GetComponent<Text> ();
		levelHoverText.color = Color.clear;
	}

	public void displayText()
	{
		levelHoverText.color = Color.white;
	}

	public void clearText()
	{
		levelHoverText.color = Color.clear;
	}
}

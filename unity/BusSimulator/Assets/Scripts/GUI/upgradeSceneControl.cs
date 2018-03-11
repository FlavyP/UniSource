using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class upgradeSceneControl : MonoBehaviour {

	/**
	 * Author: Flavian Popa
	 * 
	 **/

	private Text headerCurrency;
	private Text unlockedMessage;

	// Use this for initialization
	void Start () {
		unlockedMessage = GameObject.Find ("unlockedMessage").GetComponent<Text> ();
		headerCurrency = GameObject.Find ("currency").GetComponent<Text> ();
		if (headerCurrency) {
			headerCurrency.text = "" + PlayerPrefs.GetInt ("Currency");
		}
	}

	public void disableButton(string name)
	{
		int currentCurrency = PlayerPrefs.GetInt ("Currency");
		switch (name) {
		case "gearButton":
			if (currentCurrency >= 15) {
				unlockedMessage.text = "Gear increased";
				Invoke ("clearText", 5);
				colorButton (name);
				currentCurrency -= 15;
				PlayerPrefs.SetInt ("Currency", currentCurrency);
				headerCurrency.text = "" + PlayerPrefs.GetInt ("Currency");
			} else {
				unlockedMessage.text = "Not enough coins";
				Invoke ("clearText", 5);
			}
			break;
		case "moreResponsibilityButton":
			if (currentCurrency >= 20) {
				unlockedMessage.text = "Extra deliveries";
				Invoke ("clearText", 5);
				colorButton (name);
				currentCurrency -= 20;
				PlayerPrefs.SetInt ("Currency", currentCurrency);
				headerCurrency.text = "" + PlayerPrefs.GetInt ("Currency");
			} else {
				unlockedMessage.text = "Not enough coins";
				Invoke ("clearText", 5);
			}
			break;
		case "increasedTimeButton":
			if (currentCurrency >= 25) {
				unlockedMessage.text = "Extra Time Unlocked";
				Invoke ("clearText", 5);
				colorButton (name);
				currentCurrency -= 25;
				PlayerPrefs.SetInt ("Currency", currentCurrency);
				headerCurrency.text = "" + PlayerPrefs.GetInt ("Currency");
			} else {
				unlockedMessage.text = "Not enough coins";
				Invoke ("clearText", 5);
			}
			break;
		}
	}

	void clearText()
	{
		unlockedMessage.text = "";
	}

	void colorButton(string name)
	{
		Button button = GameObject.Find (name).GetComponent<Button>();
		if (button) {
			ColorBlock colorsBlock;
			colorsBlock = button.colors;
			colorsBlock.disabledColor = Color.red;
			button.colors = colorsBlock;
			button.interactable = false;
		}
	}
}

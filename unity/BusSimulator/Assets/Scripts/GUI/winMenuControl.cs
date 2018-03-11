using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class winMenuControl : MonoBehaviour
{
	/**
	 * Author: Flavian Popa
	 * 
	 **/

	private Text winMessageTime;
	private Text winMessageCoins;
	private Text headerCurrency;

	// Use this for initialization
	void Start ()
	{
		winMessageTime = GameObject.Find ("winMessageTime").GetComponent<Text> ();
		winMessageCoins = GameObject.Find ("winMessageCoins").GetComponent<Text> ();
		headerCurrency = GameObject.Find ("currency").GetComponent<Text> ();
		if (winMessageTime) {
			float time = PlayerPrefs.GetFloat ("Timer");
			winMessageTime.text += time.ToString("0") + " seconds";
		}
		if (winMessageCoins) {
			int currency = PlayerPrefs.GetInt ("Currency");
			winMessageCoins.text += currency + " coins\t";
			headerCurrency.text = "" + currency;
		}
	}
}

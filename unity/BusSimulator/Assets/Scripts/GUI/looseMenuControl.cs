using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class looseMenuControl : MonoBehaviour {

	/**
	 * Author: Flavian Popa
	 * 
	 **/

	private Text looseMessageCoins;
	private Text headerCurrency;

	// Use this for initialization
	void Start ()
	{
		looseMessageCoins = GameObject.Find ("looseMessageCoins").GetComponent<Text> ();
		headerCurrency = GameObject.Find ("currency").GetComponent<Text> ();
		if (looseMessageCoins) {
			int currency = PlayerPrefs.GetInt ("Currency");
			looseMessageCoins.text += currency + " coins\t";
			headerCurrency.text = "" + currency;
		}
	}
}

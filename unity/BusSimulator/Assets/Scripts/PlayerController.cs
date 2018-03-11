using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private int currency;
	private float timer;
	private int deliveries;

	public Text countdownText;
	public Text deliviriesText;
	public Text currencyText;
	public PauseMenu pause;

	// Use this for initialization
	void Start () {
		currency = PlayerPrefs.GetInt ("Currency", 0);
		timer = PlayerPrefs.GetFloat ("Timer", 300f);
		deliveries = PlayerPrefs.GetInt ("Deliveries", 3);

		updateTextGUI();

		PlayerPrefs.SetInt ("Currency", currency);
		PlayerPrefs.SetFloat ("Timer", timer);
		PlayerPrefs.SetInt ("Deliveries", deliveries);
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause.isPaused ()) {
			updateValues();
			updateTextGUI();
			
			//You loose
			if (timer < 0) {
				if (currency > 30) PlayerPrefs.SetInt ("Currency", currency - 20);
				SceneManager.LoadScene (5);
			}
			
			//You win
			if (deliveries == 0 && timer > 0) {
				PlayerPrefs.SetInt ("Currency", currency+30);
				SceneManager.LoadScene (4);
			}
		}
	}

	private void updateValues(){
		timer -= Time.deltaTime;
		deliveries = PlayerPrefs.GetInt ("Deliveries");
		PlayerPrefs.SetFloat ("Timer", timer);
		currency = PlayerPrefs.GetInt ("Currency");
	}

	private void updateTextGUI(){
		countdownText.text = timer.ToString("0");
		deliviriesText.text = deliveries.ToString();
		currencyText.text = currency.ToString();
	}
}

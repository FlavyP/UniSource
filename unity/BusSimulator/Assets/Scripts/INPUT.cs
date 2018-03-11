using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO.Ports;
using MyAssets;


	/*
	 * Author: Arnas
	 */

public class INPUT : MonoBehaviour {

	public float speed = 20f;
	public Text text;
	public GameObject pauseText;
	public GameObject horn;
	public RadioSLASHManager radio;
	public MyCarController car;
	public PauseMenu pause;

	private SerialPort sp = new SerialPort ("COM3", 9600);

	private string input;
	private string[] inp;

	private string output;

	private string currentHornInput = "0";
	private string currentRadioInput = "0";

	private float steeringValue = 0;
	private float accelerationValue = -1;
	private float handBrake = 0;
	private string pauseInput = "1";
	private string reverse = "0";

	private Text direction;

	// Use this for initialization
	void Start () {
		try {
			sp.Open ();
			sp.ReadTimeout = 20;
		} catch(System.Exception) {
		}

		direction = GameObject.Find ("direction").GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update () {

		if (sp != null && sp.IsOpen) {

			try {
				input = sp.ReadLine ();

				Debug.Log(input);

				inp = input.Split (' ');

				checkInputs ();


			} catch (System.Exception) {
			}

			moveCar ();

		} else {
			

			car.Move((Input.GetAxis("Horizontal")), (Input.GetAxis("Vertical")), (Input.GetAxis("Vertical")), (Input.GetAxis("Jump")));
			
			
			if (Input.GetKeyDown (KeyCode.P)) togglePause ();
			if (Input.GetKeyDown(KeyCode.H)) playHorn();
			if (Input.GetKeyDown(KeyCode.R)) toggleRadio();
		}
	}

	private string switchStatus(string status) {

		switch (status) {
			case "0":
				status = "1";
				break;
			case "1":
				status = "0";
				break;
			default:
				break;
		}

		return status;
	}

	private void moveCar() {

		car.Move(steeringValue, accelerationValue, accelerationValue, handBrake);

	}

	private void checkInputs(){
		// Steering
		steeringValue = float.Parse(inp[1]) * 0.8f;

		// Check Horn
		if (inp [4].ToString () == currentHornInput) playHorn();

		// Check Pause
		if (inp [5].ToString () == pauseInput) togglePause();

		// Check Pause
		if (inp [6].ToString () == currentRadioInput) toggleRadio();

		// Handbrake
		handBrake = float.Parse(inp[7]);

		Debug.Log ("hello");
		// Check reverse
		if (inp[3].ToString() == reverse) reverse = switchStatus(reverse);
		if (int.Parse(reverse) == 0) {
			direction.text = "Forward";
		} else if (int.Parse(reverse) == 1) {
			direction.text = "Backwards";
		}

		// Acceleration
		accelerationValue = float.Parse(inp[2]);

		accelerationValue = (((accelerationValue))+1)*3;
		if (accelerationValue > 1)
			accelerationValue = 1;

		if (reverse == "1")
			accelerationValue = -accelerationValue;

	}

	private void toggleRadio(){
		radio.nextS ();
		currentRadioInput = switchStatus(currentRadioInput);
	}

	private void playHorn(){
		horn.GetComponent<AudioSource>().Play();
		currentHornInput = switchStatus(currentHornInput);
	}


	public void changeStatus(bool open) {
		if (open) {
			try {
				sp.Open ();
				sp.ReadTimeout = 20;
			} catch (System.Exception) {
			}
		} else {
			try {
				sp.Close();
			} catch(System.Exception) {
			}
		}
	}

	private void togglePause(){
		if (pauseInput == "1") {
			pause.Pause ();
			pauseInput = "0";
		} else {
			pause.Resume();
			pauseInput = "1";
		}
	}

}


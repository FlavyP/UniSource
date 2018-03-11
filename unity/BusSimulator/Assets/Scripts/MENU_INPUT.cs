using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using UnityEngine.EventSystems;

	/*
	 * Author: Arnas
	 */

public class MENU_INPUT : MonoBehaviour {

	private SerialPort sp = new SerialPort ("COM3", 9600);

	private string[] inp;

	private string up;
	private string down;
	private string enter;
	private EventSystem myEventSystem;
	public List<GameObject> SelectionArray = new List<GameObject>();
	public int currentSelection = 0;

	// Use this for initialization
	void Start () {
		try {
			sp.Open ();
			sp.ReadTimeout = 20;

			myEventSystem = EventSystem.current;
		} catch(System.Exception) {
		}
	}

	// Update is called once per frame
	void Update () {

		if (sp != null && sp.IsOpen) {

			try {
				inp = sp.ReadLine ().Split (' ');

				print(inp[4] + " " + inp[5] + " " + inp[6]);

				checkInputs();

			} catch (System.Exception) {
			}
		}
	}

	private void checkInputs() {

		if (up != null && down != null && enter != null) {

			if (inp[4] != up) toggleUp();
			if (inp[5] != down) toggleDown();
			if (inp[6] != enter) toggleEnter();

		} else {
			up = inp[4];
			down = inp[5];
			enter = inp[6];
		}

	}

	private void toggleUp() {
		myEventSystem.SetSelectedGameObject(SelectionArray[getSelection(false)]);
		up = inp[4];
	}

	private void toggleDown() {
		myEventSystem.SetSelectedGameObject(SelectionArray[getSelection(true)]);
		down = inp[5];
	}

	private void toggleEnter() {
		myEventSystem.currentSelectedGameObject.GetComponent<Button> ().onClick.Invoke ();
		enter = inp[6];
	}

	private int getSelection(bool increase) {
		if (increase) {
			++currentSelection;
		} else {
			--currentSelection;
		}

		if (currentSelection < 0)
			currentSelection = SelectionArray.Count - 1;

		if (currentSelection > SelectionArray.Count)
			currentSelection = 0;

		return currentSelection;
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
}

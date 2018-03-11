using UnityEngine;
using System.Collections;

public class ObjectChild : MonoBehaviour
{
	public ObjectivesManager manager;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter (Collision collision)
	{

		if (collision.collider.tag.Equals ("Car")) {

			PlayerPrefs.SetInt ("Deliveries", PlayerPrefs.GetInt ("Deliveries") - 1);
			PlayerPrefs.SetInt ("Currency", PlayerPrefs.GetInt ("Currency") + 15);

			manager.up ();
			DestroyObject (gameObject);
			manager.visible ();
		}
	}
}

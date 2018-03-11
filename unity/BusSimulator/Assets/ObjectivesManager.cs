using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectivesManager : MonoBehaviour
{
	bool Center;
	List<Transform> objects;
	MeshRenderer mesh;
	private int counter = 1;
	public MeshRenderer disguise;

	// Use this for initialization
	void Start ()
	{
		Center = false;
		objects = new List<Transform> ();

		foreach (Transform child in transform) {
			objects.Add (child);
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void up ()
	{
		if (counter != objects.Count) 
			objects [0] = objects [counter++];
		
	}

	public Transform getObjectZero ()
	{
		if (Center == false)
			return this.transform;
		return objects [0];
	}

	void OnTriggerEnter (Collider collider)
	{
		Debug.Log (Center);
		if (collider.tag.Equals ("Car")) {
			disguise.enabled = false;
			if (Center == false)
				Center = true;
		}
	}

	public void visible ()
	{
		disguise.enabled = true;
		Center = false;
	}
	public void refresh(){
			objects = new List<Transform> ();

		foreach (Transform child in transform) {
			objects.Add (child);
		}
	}
}

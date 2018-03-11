using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour
{
	private Rigidbody rb;
	private bool allowed = true;
	private bool broken = false;
	// Use this for initialization
	void Start ()
	{
		transform.Rotate (genAposition ());
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
		Ray seekerRay = new Ray (transform.position, new Vector3 (0, 0, 10));
		if (Physics.Raycast (seekerRay, out hit, 10)) {
			if (hit.collider.tag.Equals ("Wall")) {
				
			}
		}
		if (allowed)
			transform.Translate (new Vector3 (0, 0, 0.1f));
		if (broken) {
			GetComponentInParent<RandomSpawnEnemies> ().counterGP--;	
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.tag.Equals ("Wall")) {
			allowed = false;
			breaki ();
		}

	}

	Vector3 genAposition ()
	{
		
		switch (Random.Range (1, 4)) {
		case 2:
			return new Vector3 (0, 90, 0);
		case 3:
			return new Vector3 (0, 180, 0);
		case 4:
			return new Vector3 (0, 270, 0);
		default:
			return new Vector3 (0, 0, 0);
		}
	}

	void breaki ()
	{
		for (int i = 0; i < 4; i++) {
			GetComponentInChildren<FixedJoint> ().breakForce = 5;
			GetComponentInChildren<FixedJoint> ().breakTorque = 5;
		}
		rb.AddForce (0, 50, -20f);
		StartCoroutine (wait ());
		//Destroy (gameObject);
	}

	IEnumerator wait ()
	{
		broken = false;
		yield return new WaitForSeconds (2f);
		broken = true;
	}


}

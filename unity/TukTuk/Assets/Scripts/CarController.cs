using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

	public float speed;
	public MyAssets.MyCarController myCarControllerScript;

	// Use this for initialization
	void Start ()
	{
		speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (Input.GetKey (KeyCode.Space) && ammo > 0) {
			ammo--;
			projectile = Instantiate (projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
			Rigidbody rb = projectile.GetComponent<Rigidbody> ();
			rb.AddForce (rb.transform.forward * 2000);
			StartCoroutine (removeProjectile (projectile));
		}*/

	}

	void increaseSpeed ()
	{
		myCarControllerScript.controlSpeed (5);
	}

	void decreaseSpeed ()
	{
		myCarControllerScript.controlSpeed (-5);
	}

}

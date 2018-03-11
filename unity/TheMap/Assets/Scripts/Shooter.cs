using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

	// Reference to projectile prefab to shoot
	public GameObject projectilePrefab;
	private GameObject projectile;
	public CarController myCarController;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftControl) && CarController.ammo > 0) {
			myCarController.decreaseAmmo ();
			projectile = Instantiate (projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
			Rigidbody rb = projectile.GetComponent<Rigidbody> ();
			rb.AddForce (rb.transform.forward * 2000);
			StartCoroutine (removeProjectile (projectile));
		}
	}

	IEnumerator removeProjectile (GameObject proj)
	{
		yield return new WaitForSeconds (1);
		Destroy (proj);
	}
}
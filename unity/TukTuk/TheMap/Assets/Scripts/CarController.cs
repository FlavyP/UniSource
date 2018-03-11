using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

	public int ammo;
	public float speed;
	public bool hasShield;

	private GameObject guiMessage;
	private Text guiText;

	private float timeToDisplay;

	public GameObject projectilePrefab;
	private GameObject projectile;
    
	public int hitCounts;

	// Use this for initialization
	void Start ()
	{
		ammo = 10;
		speed = 1.0f;
		hasShield = false;

		guiMessage = GameObject.Find ("guiText");
		guiText = guiMessage.GetComponent<Text> ();

		timeToDisplay = 5.0f;

		hitCounts = 3;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Shoot on mouse
		if (Input.GetMouseButtonDown (0) && ammo > 0) {
			ammo--;
			projectile = Instantiate (projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.AddForce (rb.transform.forward * 2000);
            StartCoroutine(removeProjectile(projectile));
        }

	}

    IEnumerator removeProjectile(GameObject proj)
    {
        yield return new WaitForSeconds(1);
        Destroy(proj);
    }

	void OnTriggerEnter (Collider col)
	{
		if (col.tag.Equals ("Pickup")) {
			pickRandomPickUp ();
		} else if (col.tag.Equals ("Enemy")) {
            // enemy hit
		}
	}


	void pickRandomPickUp ()
	{
		//int random = Random.Range (1, 5);
		int random = 3;
		switch (random) {
		case 1:
			//Increase speed
			if (speed < 2.0f) {
				speed += 0.1f;
				guiText.text = "Speed Increased";
				Invoke ("clearMessage", timeToDisplay);
			}
			break;
		case 2:
			//Decrease speed
			if (speed > 0.5f) {
				speed -= 0.1f;
				guiText.text = "Speed Decrease";
				Invoke ("clearMessage", timeToDisplay);
			}
			break;
		case 3:
			//Shield
			//Shield should act in the OnCollision method inside the Car functions
			if (!hasShield) {
				hasShield = true;
				guiText.text = "Shield Activated";
				Invoke ("clearMessage", timeToDisplay);
				Invoke ("deactivateShield", 5);
			}
			break;
		case 4:
			//Add ammo
			ammo += 3;
			guiText.text = "Ammo: " + ammo;
			Invoke ("clearMessage", timeToDisplay);
			break;
		}
	}

	void clearMessage ()
	{
		guiText.text = "";
	}

	void deactivateShield ()
	{
		hasShield = false;
	}
}

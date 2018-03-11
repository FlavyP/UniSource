using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{

	public static int ammo;
	public float speed;
	public bool hasShield;

	private Text guiText;
	private Text guiTextCurrentAmmo;
	private Text guiTextCurrentShield;

	private float timeToDisplay;

	public GameObject projectilePrefab;
	private GameObject projectile;
    
	public int hitCounts;

	public MyAssets.MyCarController myCarControllerScript;

	// Use this for initialization
	void Start ()
	{
		ammo = 10;
		speed = 1.0f;
		hasShield = false;

		guiText = GameObject.Find ("guiText").GetComponent<Text> ();
		guiTextCurrentAmmo = GameObject.Find ("currentAmmo").GetComponent<Text> ();
		guiTextCurrentShield = GameObject.Find ("currentShield").GetComponent<Text> ();

		timeToDisplay = 5.0f;

		hitCounts = 3;
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

		if (hitCounts == 0) {
			Application.LoadLevel ("GameOver");
		}

	}

	public void decreaseAmmo()
	{
		ammo--;
	}

	void FixedUpdate ()
	{
		guiTextCurrentAmmo.text = ammo + "";
		if (hasShield)
			guiTextCurrentShield.text = "ON";
		else
			guiTextCurrentShield.text = "OFF";
	}

	IEnumerator removeProjectile (GameObject proj)
	{
		yield return new WaitForSeconds (1);
		Destroy (proj);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag.Equals("Pickup"))
        {
            pickRandomPickUp();
        }
        else if (col.collider.tag.Equals("Projectile"))
        {
            Destroy(col.gameObject);
            Debug.Log("Hit");
            hitCounts--;
        }
    }


    void pickRandomPickUp ()
	{
		int random = Random.Range (1, 5);
		//int random = 1;
		switch (random) {
		case 1:
			//Increase speed
			increaseSpeed ();
			guiText.text = "Speed Increased";
			Invoke ("clearMessage", timeToDisplay);
			Invoke ("decreaseSpeed", 5);
			break;
		case 2:
			//Decrease speed
			decreaseSpeed ();
			guiText.text = "Speed Decrease";
			Invoke ("clearMessage", timeToDisplay);
			Invoke ("increaseSpeed", 5);
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

	void increaseSpeed ()
	{
		myCarControllerScript.controlSpeed (5);
	}

	void decreaseSpeed ()
	{
		myCarControllerScript.controlSpeed (-5);
	}

}

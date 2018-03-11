using UnityEngine;
using System.Collections;

public class RandomSpawnPickUps : MonoBehaviour
{

	private int counterGP;
	private int counterBP;
	private int maxGP;
	private int maxBP;

	// Use this for initialization
	void Start ()
	{
		counterGP = 0;
		counterBP = 0;
		maxGP = 10;
		maxBP = 10;
	}

	// Update is called once per frame
	void Update ()
	{

		GameObject[] goodP = GameObject.FindGameObjectsWithTag ("GoodP");
		GameObject[] badP = GameObject.FindGameObjectsWithTag ("BadP");
		if (goodP.Length < maxGP)
			spawnGoodPotion ();
		if (badP.Length < maxBP)
			spawnBadPotion ();
		
			

	}

	void spawnGoodPotion ()
	{
		float x = (float)Random.Range (0, 200);
		float y = 0.5f;
		float z = (float)Random.Range (0, 200);
		Vector3 position = new Vector3 (x, y, z);
		GameObject goodPotion = (GameObject)Instantiate (Resources.Load ("Good Potion"), position, Quaternion.identity);
		goodPotion.name = "Good Potion " + (counterGP + 1);
		goodPotion.transform.parent = gameObject.transform;
		counterGP++;

	}

	void spawnBadPotion ()
	{
		float x = (float)Random.Range (0, 200);
		float y = 0.5f;
		float z = (float)Random.Range (0, 200);
		Vector3 position = new Vector3 (x, y, z);
		GameObject goodPotion = (GameObject)Instantiate (Resources.Load ("Bad Potion"), position, Quaternion.identity);
		goodPotion.transform.parent = gameObject.transform;
		counterBP++;
	}
}

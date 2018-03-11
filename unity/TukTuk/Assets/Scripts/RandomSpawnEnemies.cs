using UnityEngine;
using System.Collections;

public class RandomSpawnEnemies : MonoBehaviour
{

	public int counterGP;

	// Use this for initialization
	void Start ()
	{
		counterGP = 0;
	}

	// Update is called once per frame
	void Update ()
	{

		GameObject[] enemy = GameObject.FindGameObjectsWithTag ("Enemy");

		if (counterGP < 15)
			spawnGoodPotion ();
		
	}

	void spawnGoodPotion ()
	{	
		float x = (float)Random.Range (1, 200);
		float y = 0.5f;
		float z = (float)Random.Range (1, 200);
		Vector3 position = new Vector3 (x, y, z);
		GameObject Enemy = (GameObject)Instantiate (Resources.Load ("Enemy"), position, Quaternion.identity);
		Enemy.name = "EnemyCar" + (counterGP + 1);
		counterGP++;
		Enemy.transform.parent = gameObject.transform;
	}
}

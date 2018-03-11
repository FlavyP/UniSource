using UnityEngine;
using System.Collections;

public class RandomSpawnAvoiding : MonoBehaviour
{

	public GameObject coinPrefab;
	private GameObject coin;

	private Vector3 targetPosition;
	private float checkRadius;

	public int maxCoins;

	// Use this for initialization
	void Start ()
	{
		checkRadius = 5.0f;
		maxCoins = 15;
	}
	
	// Update is called once per frame
	void Update ()
	{
		randomPosition ();
		Collider[] checkResult = Physics.OverlapSphere (targetPosition, checkRadius);

		//Get all coins
		GameObject[] coins = GameObject.FindGameObjectsWithTag ("Pickup");

		if (checkResult.Length == 0) {
			if (coins.Length <= maxCoins) {
				Spawn ();
			}
		}
	}

	void Spawn ()
	{
		coin = Instantiate (coinPrefab, this.targetPosition, Quaternion.identity) as GameObject;
	}

	void randomPosition ()
	{
		float x = (float)Random.Range (1, 100);
		float y = -21f;
		float z = (float)Random.Range (1, 100);
		this.targetPosition = new Vector3 (x, y, z);
	}
}

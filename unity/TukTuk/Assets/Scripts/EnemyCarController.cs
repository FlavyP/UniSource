using UnityEngine;
using System.Collections;

public class EnemyCarController : MonoBehaviour
{

	public int ammo;
	public bool hasShield;

	public GameObject projectilePrefab;
	private GameObject projectile;

	public int hitCounts;

    NavMeshAgent agent;
    public Transform target;

    public MyEnemyAssets.MyEnemyCarController MyEnemyCarControllerScript;

	// Use this for initialization
	void Start ()
	{
		ammo = 10;
		hasShield = false;
		hitCounts = 3;
        agent = GetComponent<NavMeshAgent>();
    }

	// Update is called once per frame
	void Update ()
	{
        //Shoot on mouse
        //if (Input.GetMouseButtonDown (0) && ammo > 0) {
        //ammo--;
        //projectile = Instantiate (projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
        //Rigidbody rb = projectile.GetComponent<Rigidbody> ();
        //rb.AddForce (rb.transform.forward * 2000);
        //StartCoroutine (removeProjectile (projectile));
        //}
        
        checkAndshoot();
        if (hitCounts == 0) {
			Destroy (gameObject);
		}
	}

	IEnumerator removeProjectile (GameObject proj)
	{
		yield return new WaitForSeconds (1);
		Destroy (proj);
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag.Equals ("Pickup")) {
			pickRandomPickUp ();
		} else if (col.collider.tag.Equals ("Projectile")) {
			Destroy (col.gameObject);
			Debug.Log ("Hit");
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
			Invoke ("decreaseSpeed", 5);
			break;
		case 2:
			//Decrease speed
			decreaseSpeed ();
			Invoke ("increaseSpeed", 5);
			break;
		case 3:
			//Shield
			//Shield should act in the OnCollision method inside the Car functions
			if (!hasShield) {
				hasShield = true;
				Invoke ("deactivateShield", 5);
			}
			break;
		case 4:
			//Add ammo
			ammo += 3;
			break;
		}
	}

	void deactivateShield ()
	{
		hasShield = false;
	}

	void increaseSpeed ()
	{
		//myEnemyCarControllerScript.controlSpeed (5);
	}

	void decreaseSpeed ()
	{
		//myEnemyCarControllerScript.controlSpeed (-5);
	}
    void checkAndshoot() {
        if (ammo != 0) {
            agent.SetDestination(target.position);

           
            if (detection())
            {
                
                ammo--;
                projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.AddForce(rb.transform.forward * 2000);
                StartCoroutine(removeProjectile(projectile));
            }
        }
        else
        {
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Pickup");
            agent.SetDestination(coins[1].transform.position);
        }
    }
    bool detection()
    {
        RaycastHit hit;

       
        Ray detector = new Ray(transform.position, Vector3.back);
        
        if (Physics.Raycast(detector, out hit, Mathf.Infinity))
        {
           
            if (hit.collider.tag.Equals("Car"))
            {
                return true;
            }
        }
        return false;
    }

}

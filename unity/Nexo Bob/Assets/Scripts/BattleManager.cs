using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;

    public Text waitingForInputTextLabel;
    public Text scannedCardText;

    public GameObject playerPosition;
    public GameObject enemyPosition;

    private bool isPlayerTurn = true;
    private bool isEnemyTurn = false;

    private Vector3 tempPosition;
    private bool tempFinished = false;
    private bool tempReached = false;
    private NavMeshAgent tempAgent;
    private bool battleStarted = false;
    private bool inputReceived = false;
    private bool isCardScanned = false;
	private bool playerWon = false;

    private int battleTurns = 0;
    private int stars = 0;
    private int animationPlayed = 0;

    public Rigidbody egg;
    public Rigidbody pie;
    public Transform shotPosPlayer;
    public Transform shotPosEnemy;
    public float shotForce = 1000f;
    public float moveSpeed = 10f;

    public Text heroDamage;
    public Text evilDamage;

    // Use this for initialization
    void Start()
    {
        // Quick fix fot lumbering animation getting stuck
        //enemy.GetComponent<Animation>()["Lumbering"].wrapMode = WrapMode.Once;
        //enemy.GetComponent<Animation>()["Idle"].wrapMode = WrapMode.Once;
        //enemy.GetComponent<Animation>()["Armature|Idle"].wrapMode = WrapMode.Once;

        //player.GetComponent<Animation>()["Armature|Throwing"].wrapMode = WrapMode.Once;
        //player.GetComponent<Animation>()["attack"].wrapMode = WrapMode.Once;
        //player.GetComponent<Animation>()["jump"].wrapMode = WrapMode.Once;
    }

    public void cardScanned(string text)
    {
        scannedCardText.text = "Scanned card: " + text;
        isCardScanned = true;
    }

    public void resetCardScanned()
    {
        scannedCardText.text = "";
        isCardScanned = false;
    }

    public bool isBattleFinished()
    {
        return !battleStarted;
    }

    // Update is called once per frame
    void Update()
    {
        if (battleStarted)
        {
            if (isPlayerTurn)
            {
                Debug.Log("Player turn!");
                StartCoroutine(playerTurn());
                isPlayerTurn = false;
                battleTurns++;
            }
            else if (isEnemyTurn)
            {
                Debug.Log("Enemy turn!");
                StartCoroutine(enemyTurn());
                isEnemyTurn = false;
            }
            else
            {
                // Do nothing
            }
        }
    }

    public void startBattle()
    {
        battleStarted = true;
    }

    public IEnumerator playerTurn()
    {
        yield return StartCoroutine(waitForInput());
        while (!inputReceived) { yield return new WaitForSeconds(0); }


        yield return StartCoroutine(move(player, enemy));
        while (!tempFinished) { yield return new WaitForSeconds(0); }

        tempFinished = false;
        isEnemyTurn = true;
        yield return null;
    }

    IEnumerator enemyTurn()
    {
        yield return StartCoroutine(move(enemy, player));

        while (!tempFinished) { yield return new WaitForSeconds(0); }

        tempFinished = false;
        isPlayerTurn = true;
        yield return null;
    }

    IEnumerator move(GameObject objectToMove, GameObject target)
    {
        // Set the temp position
        if (objectToMove.tag == "Player")
            tempPosition = enemyPosition.transform.position;
        else
            tempPosition = playerPosition.transform.position;

        objectToMove.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        // Set the temp agent
        tempAgent = objectToMove.GetComponent<NavMeshAgent>();
        tempAgent.Resume();

        // Go to the target position
        tempAgent.SetDestination(target.GetComponent<NavMeshAgent>().transform.position);

        // Play animation
        if (objectToMove.tag == "Player")
            objectToMove.GetComponent<Animation>().Play("Armature|Walking");
        //objectToMove.GetComponent<Animation>().Play("run");
        else
            objectToMove.GetComponent<Animation>().Play("Armature|Walk");

        // While the target isn't reached - wait
        while (!tempReached)
        {
            tempReached = objectToMove.GetComponent<BattleObject>().reached;
            yield return new WaitForSeconds(0);
        }

        tempAgent.Stop();
        Debug.Log("Target reached!");

        // Fix the value
        tempReached = changeToNotReached();

        // --- Attack begin
        // Play Animation
        if (objectToMove.tag == "Player")
        {
            switch (scannedCardText.text)
            {
                case "Scanned card: shield5":
                    objectToMove.GetComponent<Animation>().Play("Armature|Throwing");
                    //objectToMove.GetComponent<Animation>().Play("attack");
                    Rigidbody shotEgg = Instantiate(egg, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotEgg.AddForce(shotPosPlayer.forward * shotForce);
                    animationPlayed = 1;
                    break;
                case "Scanned card: shield":
                    objectToMove.GetComponent<Animation>().Play("Armature|Throwing");
                    Rigidbody shotPie = Instantiate(pie, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotPie.AddForce(shotPosPlayer.forward * shotForce);
                    //objectToMove.GetComponent<Animation>().Play("jump");
                    animationPlayed = 2;
                    break;
                default:
                    objectToMove.GetComponent<Animation>().Play("Armature|Throwing");
                    //objectToMove.GetComponent<Animation>().Play("attack");
                    animationPlayed = 3;
                    break;
            }
            //objectToMove.GetComponent<Animation>().Play("attack");
        }
        else {
            switch (Random.Range(1, 6))
            {
                case 1:
                    objectToMove.GetComponent<Animation>().Play("Armature|Attack");
                    Rigidbody shotEgg = Instantiate(egg, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotEgg.AddForce(shotPosEnemy.forward * shotForce);
                    animationPlayed = 1;
                    break;
                case 2:
                    objectToMove.GetComponent<Animation>().Play("Armature|Attack");
                    Rigidbody shotPie = Instantiate(pie, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotPie.AddForce(shotPosEnemy.forward * shotForce);
                    animationPlayed = 1;
                    break;
                case 3:
                    objectToMove.GetComponent<Animation>().Play("Armature|Attack");
                    Rigidbody shotEgg2 = Instantiate(egg, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotEgg2.AddForce(shotPosEnemy.forward * shotForce);
                    animationPlayed = 2;
                    break;
                case 4:
                    objectToMove.GetComponent<Animation>().Play("Armature|Attack");
                    Rigidbody shotPie2 = Instantiate(pie, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotPie2.AddForce(shotPosEnemy.forward * shotForce);
                    animationPlayed = 2;
                    break;
                case 5:
                    objectToMove.GetComponent<Animation>().Play("Armature|Attack");
                    Rigidbody shotEgg3 = Instantiate(egg, shotPosPlayer.position, shotPosPlayer.rotation) as Rigidbody;
                    shotEgg3.AddForce(shotPosEnemy.forward * shotForce);
                    animationPlayed = 2;
                    break;
                default:
                    break;
            }
            //objectToMove.GetComponent<Animation>().Play("Lumbering");
        }

        // Wait for animation to finish
        while (objectToMove.GetComponent<Animation>().isPlaying)
        {
            yield return new WaitForSeconds(0);
        }

        int damage = 0;

        switch (animationPlayed)
        {
            case 1:
                damage = Random.Range(13, 22);
                target.GetComponent<BattleObject>().takeDamage(damage);
                if (objectToMove.tag == "Player")
                {
                    evilDamage.text = "-" + damage;
                    Invoke("clearEvilDamage", 3);
                }
                else {
                    heroDamage.text = "-" + damage;
                    Invoke("clearHeroDamage", 3);
                }
                break;
            case 2:
                damage = Random.Range(22, 29);
                target.GetComponent<BattleObject>().takeDamage(damage);
                if (objectToMove.tag == "Player")
                {
                    evilDamage.text = "-" + damage;
                    Invoke("clearEvilDamage", 3);
                }
                else {
                    heroDamage.text = "-" + damage;
                    Invoke("clearHeroDamage", 3);
                }
                break;
            case 3:
                damage = Random.Range(25, 37);
                target.GetComponent<BattleObject>().takeDamage(damage);
                if (objectToMove.tag == "Player")
                {
                    evilDamage.text = "-" + damage;
                    Invoke("clearEvilDamage", 3);
                }
                else {
                    heroDamage.text = "-" + damage;
                    Invoke("clearHeroDamage", 3);
                }
                break;
            default:
                break;
        }

        //target.GetComponent<BattleObject>().takeDamage(35);
        // --- Attack end

        // Check if battle is over
        if (target.GetComponent<BattleObject>().willPower <= 0)
        {

			// Player won
            if (objectToMove.tag == "Player")
            {
				PlayerPrefs.SetInt("LevelCompleted", Application.loadedLevel);
				determineStars(battleTurns);
				playerWon = true;
			}
			battleStarted = false;
			battleTurns = 0;
        }

        else if (objectToMove.GetComponent<BattleObject>().willPower <= 0)
        {

			// Player lost
            if (target.tag == "Player")
            {
				PlayerPrefs.SetInt("LevelCompleted", Application.loadedLevel);
				determineStars(8); // Receive only 1 star
				playerWon = false;
			}
			battleStarted = false;
			battleTurns = 0;
        }
        else
        {

            if (objectToMove.tag == "Player")
            {
                objectToMove.GetComponent<Animation>().Play("Armature|Walking");
                //objectToMove.GetComponent<Animation>().Play("run");
            }
            else
                objectToMove.GetComponent<Animation>().Play("Armature|Walk");

            // Go back to the original position
            tempAgent.Resume();
            objectToMove.GetComponent<NavMeshAgent>().SetDestination(tempPosition);


            // While the original position isn't reached - wait
            while (!tempReached)
            {
                scannedCardText.text = objectToMove.GetComponent<NavMeshAgent>().remainingDistance.ToString();
                // Check if the position is reached
                if (objectToMove.GetComponent<NavMeshAgent>().remainingDistance < 0.2f)
                {
                    scannedCardText.text = "ok";

                    // Rotate back to target
                    yield return rotateTowards(objectToMove, target);

                    if (objectToMove.tag == "Player")
                        objectToMove.GetComponent<Animation>().Play("idle");
                    //objectToMove.GetComponent<Animation>().Play("Armature|Throwing");
                    else
                        objectToMove.GetComponent<Animation>().Play("Armature|Idle");

                    tempReached = true;
                }

                yield return new WaitForSeconds(0);
            }


            tempAgent.Stop();

            // Fix the value
            tempReached = changeToNotReached();

            tempFinished = true;
        }

        objectToMove.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        yield return null;
    }

    private bool changeToNotReached()
    {
        player.GetComponent<BattleObject>().reached = false;
        enemy.GetComponent<BattleObject>().reached = false;

        return false;
    }

    IEnumerator rotateTowards(GameObject objectToRotate, GameObject target)
    {
        Vector3 direction = (target.transform.position - objectToRotate.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        yield return rotateTowards(objectToRotate, lookRotation);
    }

    IEnumerator rotateTowards(GameObject objectToRotate, Quaternion lookRotation)
    {

        //while (objectToRotate.transform.rotation != lookRotation)
        //{
        objectToRotate.transform.rotation = Quaternion.Slerp(objectToRotate.transform.rotation, lookRotation, Time.deltaTime * 100f);
        yield return new WaitForSeconds(0);
        //}

        yield return null;
    }

    // Wait for input
    IEnumerator waitForInput()
    {
        inputReceived = false;
        waitingForInputTextLabel.gameObject.SetActive(true);
        resetCardScanned();

        while (true)
        {
            if (isCardScanned)
            {
                inputReceived = true;
                waitingForInputTextLabel.gameObject.SetActive(false);
                break;
            }

            yield return new WaitForSeconds(0);
        }

        yield return null;
    }

    private void determineStars(int battleTurns)
    {
        switch (battleTurns)
        {
            case 3:
                setStars(5);
                stars = 5;
                break;
            case 4:
                setStars(4);
                stars = 4;
                break;
            case 5:
                setStars(3);
                stars = 3;
                break;
            case 6:
                setStars(3);
                stars = 3;
                break;
            case 7:
                setStars(2);
                stars = 2;
                break;
            case 8:
                setStars(1);
                stars = 1;
                break;
        }
    }

    private void setStars(int stars)
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Forest":
                float forestStars = PlayerPrefs.GetFloat("ForestStars");
                forestStars += stars;
                PlayerPrefs.SetFloat("ForestStars", forestStars);
                break;
            case "WaterfallMountain":
                float waterfallStars = PlayerPrefs.GetFloat("WaterfallMountainStars");
                waterfallStars += stars;
                PlayerPrefs.SetFloat("WaterfallMountainStars", waterfallStars);
                break;
            case "LavaMountain":
                float lavaStars = PlayerPrefs.GetFloat("LavaMountainStars");
                lavaStars += stars;
                PlayerPrefs.SetFloat("LavaMountainStars", lavaStars);
                break;
        }
    }

    public int getStars()
    {
        return stars;
    }

    private void clearHeroDamage()
    {
        heroDamage.text = "";
    }

    private void clearEvilDamage()
    {
        evilDamage.text = "";
    }

	public bool getPlayerWon()
	{
		return playerWon;
	}
}

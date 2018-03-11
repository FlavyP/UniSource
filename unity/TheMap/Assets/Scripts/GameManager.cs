using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // make game manager public static so can access this from other scripts
    public static GameManager gm;

    // public variables
    public int score = 0;

    public bool canBeatLevel = false;
    public int beatLevelScore = 0;

    public float startTime = 5.0f;

    public Text mainScoreDisplay;
    public Text mainTimerDisplay;
    public Text playAgainDisplay;

    public GameObject gameOverScoreOutline;
    public GameObject playAgainOutline;

    public string playAgainLevelToLoad;
    public bool gameIsOver = false;

    private float currentTime;

    // setup the game
    void Start()
    {

        // set the current time to the startTime specified
        currentTime = startTime;

        // get a reference to the GameManager component for use by other scripts
        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();

        // init scoreboard to 0
        mainScoreDisplay.text = "0";

        // inactivate the gameOverScoreOutline gameObject, if it is set
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(false);

        // inactivate the playAgainButtons gameObject, if it is set
        if (playAgainOutline)
            playAgainOutline.SetActive(false);
    }

    // this is the main game event loop
    void Update()
    {
        if (!gameIsOver)
        {
            if (canBeatLevel && (score >= beatLevelScore))
            {  // check to see if beat game
                BeatLevel();
            }
            else if (currentTime < 0)
            { // check to see if timer has run out
                EndGame();
            }
            else { // game playing state, so update the timer
                currentTime -= Time.deltaTime;
                mainTimerDisplay.text = currentTime.ToString("0.00");
                playAgainDisplay.text = "";
            }
        }
    }

    void EndGame()
    {
        // game is over
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        mainTimerDisplay.text = "GAME OVER";
        playAgainDisplay.text = "PLAY AGAIN";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        // activate the playAgainButtons gameObject, if it is set 
        if (playAgainOutline)
            playAgainOutline.SetActive(true);
    }

    void BeatLevel()
    {
        // game is over
        gameIsOver = true;

        // repurpose the timer to display a message to the player
        mainTimerDisplay.text = "LEVEL COMPLETE";

        // activate the gameOverScoreOutline gameObject, if it is set 
        if (gameOverScoreOutline)
            gameOverScoreOutline.SetActive(true);

        // inactivate the playAgainButtons gameObject, if it is set
        if (playAgainOutline)
            playAgainOutline.SetActive(true);
    }

    // public function that can be called to update the score or time
    public void targetHit(int scoreAmount)
    {
        // increase the score by the scoreAmount and update the text UI
        score += scoreAmount;
        mainScoreDisplay.text = score.ToString();

        // update the text UI
        mainTimerDisplay.text = currentTime.ToString("0.00");
    }

    // public function that can be called to restart the game
    public void RestartGame()
    {
        // we are just loading a scene (or reloading this scene)
        // which is an easy way to restart the level
        SceneManager.LoadScene(playAgainLevelToLoad);
    }
}
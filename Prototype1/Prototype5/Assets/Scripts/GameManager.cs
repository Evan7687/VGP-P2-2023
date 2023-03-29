//Using statemetns are like import statements
//They bring code in from another program into your program

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //variables
    public List<GameObject> targets;
    private float spawnRate = 2.0f;
    public TextMeshProUGUI scoreText;
    private int score;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive; //bool is short for boolean
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI livesText;
    private int lives;
    public GameObject pauseScreen;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the user has pressed the P key
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    //this is a method header or method signature for UpdateScore
    //it has a parameter "scoreToAdd"
    public void UpdateScore(int scoreToAdd)
    {
        //+= is like score = score + scoreToAdd
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;
        livesText.text = "Lives: " + lives;
        //Tells us when to end the game if we are out of lives
        if (lives <= 0)
        {
            //This is a method call
            GameOver();
        }
    }

    //This is another method header/method signature that doesn't have a parameter
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //StartGame has a "parameter" of difficulty which is an int
    public void StartGame(int difficulty)
    {
        //Change the spawnrate based on the choosen difficulty
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }

    void ChangePaused()
    {
        if(!paused)     //if not paused, then pause game
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else    //else if paused, then unpause it
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

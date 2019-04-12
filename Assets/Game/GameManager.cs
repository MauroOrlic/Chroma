using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] GameObject playerShip;
    GameObject Manager;
    [SerializeField] GameObject ScoreManager;
    [SerializeField] GameObject GameOverContainer;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject InstructionsContainer;
    [SerializeField] GameObject LifeTrackerContainer;
    GameObject topScoreDisplayValue;
    GameObject GOScoreDisplayValue;
    public bool gameIsPaused;
    public int playerLives;
    public int currentScore;

    void Start()
    {
        //PauseMenu = GameObject.Find("PauseMenu");
        //InstructionsContainer = GameObject.Find("InstructionsContainer");
        Manager = GameObject.Find("Manager");
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;        
        playerLives = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExitHit()
    {
        Manager.GetComponent<Manager>().LoadMainMenu();
    }
    public void GameOver()
    {
        playerShip.GetComponent<PlayerMovement>().isEnabled = false;
        playerShip.GetComponent<PlayerControls>().isEnabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Manager.GetComponent<Manager>().gameScore = currentScore;
        GameOverContainer.SetActive(true);

        Manager.GetComponent<Manager>().UpdateTopScore();

        topScoreDisplayValue = GameObject.Find("TopScoreDisplayValue");
        GOScoreDisplayValue = GameObject.Find("GOScoreDisplayValue");

        topScoreDisplayValue.GetComponent<Text>().text = Manager.GetComponent<Manager>().topGameScore.ToString("D8");
        GOScoreDisplayValue.GetComponent<Text>().text = Manager.GetComponent<Manager>().gameScore.ToString("D8");
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        InstructionsContainer.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<AudioSource>().Pause();
        playerShip.GetComponent<PlayerMovement>().isEnabled = false;
        playerShip.GetComponent<PlayerControls>().isEnabled = false;
        gameIsPaused = true;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        InstructionsContainer.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        gameObject.GetComponent<AudioSource>().UnPause();
        playerShip.GetComponent<PlayerMovement>().isEnabled = true;
        playerShip.GetComponent<PlayerControls>().isEnabled = true;
        gameIsPaused = false;
    }
    public void increaseScore(int scoreGained)
    {
        currentScore += scoreGained;
        ScoreManager.GetComponent<ScoreBehaviour>().UpdateScoreDisplay(currentScore);
    }
    public void increasePlayerLives(int livesGained)
    {
        playerLives = Mathf.Max(0, playerLives + livesGained);        
        LifeTrackerContainer.GetComponent<LifeTrackerBehaviour>().UpdateLifeDisplayValue(playerLives);
        if (playerLives < 1)
        {
            GameOver();
        }
    }
}

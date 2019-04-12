using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    GameObject Manager;
    GameObject GameManager;
    KeyCode Pause;
    bool gameIsPaused;

    void Start()
    {
        gameIsPaused = false;
        GameManager = GameObject.Find("GameManager");
        Manager = GameObject.Find("Manager");

        Pause = Manager.GetComponent<Manager>().Pause;
    }

    void Update()
    {
        if (Input.GetKeyDown(Pause))
        {
            PauseKeyHit();
        }
    }
    void PauseKeyHit(){
        if(gameIsPaused)
        {
            GameManager.GetComponent<GameManager>().UnpauseGame();
            gameIsPaused = false;
        }
        else
        {
            GameManager.GetComponent<GameManager>().PauseGame();
            gameIsPaused = true;
        }
    }
    public void ResumeHit()
    {
        GameManager.GetComponent<GameManager>().UnpauseGame();
        gameIsPaused = false;
    }
    public void InstructionsHit()
    {
        Debug.Log("Instruct. hit!");
    }
    public void ExitHit()
    {
        GameManager.GetComponent<GameManager>().ExitHit();
        Debug.Log("Exit hit!");
    }
}

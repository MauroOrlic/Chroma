using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public KeyCode Fire;
    public KeyCode Clear;
    public KeyCode AddRed;
    public KeyCode AddGreen;
    public KeyCode AddBlue;
    public KeyCode SubtractColor;
    public KeyCode Pause;

    public int gameScore;
    public int topGameScore;

    public float volumeMaster;
    public float volumeSFX;
    public float volumeMusic;



    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.HasKey("topGameScore"))
        {
            topGameScore = PlayerPrefs.GetInt("topGameScore");
        }
        else
        {
            topGameScore = 0;
            PlayerPrefs.SetInt("topGameScore", topGameScore);
        }

        if (PlayerPrefs.HasKey("volumeMaster"))
        {
            volumeMaster = PlayerPrefs.GetFloat("volumeMaster");
        }
        else
        {
            volumeMaster = 1f;
            PlayerPrefs.SetFloat("volumeMaster", volumeMaster);
        }
        if (PlayerPrefs.HasKey("volumeSFX"))
        {
            volumeSFX = PlayerPrefs.GetFloat("volumeSFX");
        }
        else
        {
            volumeSFX = 0.5f;
            PlayerPrefs.SetFloat("volumeSFX", volumeSFX);
        }

        if (PlayerPrefs.HasKey("volumeMusic"))
        {
            volumeMusic = PlayerPrefs.GetFloat("volumeMusic");
        }
        else
        {
            volumeMusic = 0.5f;
            PlayerPrefs.SetFloat("volumeMusic", volumeMusic);
        }
    }
    void Start()
    {


        Fire = KeyCode.Mouse0;
        Clear = KeyCode.Mouse1;
        AddRed = KeyCode.Q;
        AddGreen = KeyCode.W;
        AddBlue = KeyCode.E;
        SubtractColor = KeyCode.LeftShift;
        Pause = KeyCode.Escape;

        gameScore = 0;
    }
    public void ResetScore()
    {
        gameScore = 0;
    }
    public void ResetTopScore()
    {
        topGameScore = 0;
        ResetScore();
        UpdateTopScore();
    }
    public void UpdateTopScore()
    {
        if (gameScore > topGameScore)
        {
            topGameScore = gameScore;
        }
        PlayerPrefs.SetInt("topGameScore", topGameScore);
    }
    public void UpdateSettings()
    {
        PlayerPrefs.SetFloat("volumeMaster", volumeMaster);
        PlayerPrefs.SetFloat("volumeSFX", volumeSFX);
        PlayerPrefs.SetFloat("volumeMusic", volumeMusic);
    }
    public void LoadGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}

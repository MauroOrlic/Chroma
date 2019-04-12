using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{

    public Text scoreDisplayValue;
    //public int currentScore;

    void Start()
    {
        scoreDisplayValue = GameObject.Find("ScoreDisplayValue").GetComponent<Text>();
    }

    void Update()
    {

    }
    public void UpdateScoreDisplay(int newScore)
    {
        scoreDisplayValue.text = newScore.ToString("D8");
    }
}

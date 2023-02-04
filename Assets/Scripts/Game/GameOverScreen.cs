using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text totalScore;
    public ScoreCounter scoreCounter;
    public int TotalScore;

    void Start()
    {

    }


    void Update()
    {
        
    }
    public void ShowTotalScore()
    {
      TotalScore = scoreCounter.CurrentScore;
      totalScore.text = "SCORE: " + TotalScore;
    }

}

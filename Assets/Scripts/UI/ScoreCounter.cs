using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text ScoreCounterText;
    public int CurrentScore;
    int StartScore = 0;
    bool jasomou = false; 
    void Start()
    {
        CurrentScore = StartScore;
    }


    void Update()
    {
        if (((int)TimeCounter.CurrentTime) % 10 == 0 && ((int)TimeCounter.CurrentTime != 0)) // de o numero for divisivel por 10
        {
            if (!jasomou)
            {
                PlusPointsbyTime(100); // ganhar 10 pontos
                
            }

        }
        if (((int)TimeCounter.CurrentTime) % 10 != 0) // se o numero não for divisivel por 10
        {
            jasomou = false; // pode somar denovo
        }
        

        
        ScoreCounterText.text = "Score: " + CurrentScore.ToString(); // mostrar como texto no canvas

    }
    public void PlusPointsbyTime(int num)
    {
        CurrentScore += num; // aumenta os pontos
        jasomou = true; // ja somou
    }

    public void PlusPoints (int num)
    {
        CurrentScore += num;
    }

}
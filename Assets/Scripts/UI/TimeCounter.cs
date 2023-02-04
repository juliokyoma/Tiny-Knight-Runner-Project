using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //importing
    public HudManager hudManager;
    public Text TimeCounterText;


    int StartTime = 0;
    public static float CurrentTime;

    void Start()
    {
        
        CurrentTime = StartTime;
        //isPaused = false;
    }

    
    void Update()
    {
        Stage01Timer();
    }
    public void PauseTimeCounter()
    {
       
    }
    public void Stage01Timer()
    {
        if (GameManager.IsPlaying)
        {
            CurrentTime += 1 * Time.deltaTime;
        }
        TimeCounterText.text = ((int)CurrentTime).ToString();

    }
}


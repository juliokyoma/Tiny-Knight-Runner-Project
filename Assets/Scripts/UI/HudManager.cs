using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject displayHearts;
    public GameObject pauseMenu;
    public GameObject pauseMenuOptions;
    public GameObject gameOverScreen;
    public static bool isPaused;
    public static bool isFinish;
    private enum State {GameOverScreen, PauseScreen, Gameplay}
    // Start is called before the first frame update
    void Awake()
    {
        pauseMenu.SetActive(false);
        gameOverScreen.SetActive(false);    
        pauseMenuOptions.SetActive(false);
        isPaused = false;
        isFinish = false;
        Time.timeScale = 1f;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        if(!isFinish) {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                pauseMenu.SetActive(true);
                displayHearts.SetActive(false);
                Time.timeScale = 0f;
                isPaused = true;
            }
            Debug.Log("pause");
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        pauseMenuOptions.SetActive(false);
        displayHearts.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void GameOver()
    {
        isFinish = true;
        isPaused = true;
        gameOverScreen.SetActive(true);

    }
}

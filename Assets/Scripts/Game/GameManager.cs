using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool IsPlaying;
    public GameObject gameOverScreen;
    void Start()
    {
        
        
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1){ // se a cena for stagio 1 e nao estiver pausado esta jogando
            if (!HudManager.isPaused)
            {
                IsPlaying = true;
            } else
            {
                IsPlaying = false;
            }
        }
        
    }
    
}

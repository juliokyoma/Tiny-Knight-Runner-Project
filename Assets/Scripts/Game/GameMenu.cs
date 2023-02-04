using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    
    void start() {
        OpenMenu();
    }
    public void OpenMenu (){
        int SceneHistory = (SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("Menu");
        GameManager.IsPlaying = false;
    }
   public void OpenLevel_1 (){
        SceneManager.LoadScene("Stage_01");
        GameManager.IsPlaying = true;
   }
    public void Quit()
    {
           Application.Quit();
    }
}

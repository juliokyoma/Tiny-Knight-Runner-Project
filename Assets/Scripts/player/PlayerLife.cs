using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    //LIFE
    public int lifePlayer; // vida atual do jogador
    public int maxlifePlayer; // numero de vida que o jogador começa

    //INHITABLE
    public bool playerInhitable = false;

    //UI
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;

    //Importing
    public DestroyPlayer destroyPlayer; // para destruir o player caso ele morra
    public HudManager hudManager; // para mostrar na hud do jogo a vida do player
    public GameOverScreen gameOverScreen; // para mostrar o score na tela de game over
    public PlayerAnimation playerAnimation;
    private delegate void EndGame();
    private EndGame endGame;

    // Start is called before the first frame update
    private void Awake()
    {
        

        endGame = destroyPlayer.PlayerDie;
        endGame += gameOverScreen.ShowTotalScore;
        endGame += hudManager.GameOver;
    }
    void Start()
    {
        lifePlayer = maxlifePlayer;
       
    }

    // Update is called once per frame
    void Update()
    {
        //DISPLAY HEARTS UI
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lifePlayer)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        
    }
    public void takeDamage(int amount) // função tomar dano
    {
        if (!playerInhitable)
        {
            lifePlayer -= amount; // vc atual do jogador menos a quantidade de dano recebida
            if (lifePlayer <= 0)
            {
                endGame();
               
            }
            else
            {
                playerAnimation.SetHurtAnimation();
                playerInhitable = true;
                this.Wait(1, (DisablePlayerInhitable));
            }
        }
    }
    public void DisablePlayerInhitable()
    {
        playerInhitable = false;
    }
}


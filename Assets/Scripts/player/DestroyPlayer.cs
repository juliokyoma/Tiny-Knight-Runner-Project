using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    #region Instanciating 

    private BoxCollider2D boxCollider2D;
    private PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;
    public GameManager gameManager;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    #endregion
    public void PlayerDie()
    {

        playerMovement.PlayerJumpStarted(ref playerMovement.jumpForce);
        playerAnimation.EnablePlayerRotate();
        boxCollider2D.enabled = false;
    }
}

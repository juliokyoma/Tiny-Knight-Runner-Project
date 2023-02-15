using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerInputActions playerInputActions;
    private PlayerMovement playerMovement;
    private PlayerAnimation playerAnimation;
    private float TValue;
    public HudManager hudManager;

    #region Events
    public delegate void playerAttack();
    public static event playerAttack OnPlayerAttacked;

    public delegate void playerMove();
    public static event playerMove OnPlayerMove;

    public delegate void playerJump(ref float force);
    public static event playerJump OnPlayerJump;                    
    #endregion

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();

        playerInputActions.Player.Jump.started += context => playerMovement.PlayerJumpStarted(ref playerMovement.jumpForce);
        
        playerInputActions.Player.Jump.canceled += context => playerMovement.PlayerJumpCanceled();

        playerInputActions.Player.Attack.started += context => OnPlayerAttacked();

        playerInputActions.Player.Pause.started += context => hudManager.PauseGame();
    }
    private void FixedUpdate()
    {
        TValue = playerInputActions.Player.Move.ReadValue<float>();
        playerMovement.PlayerMove(TValue, ref playerMovement.playerSpeed);
        if (TValue == 0 && playerAnimation.state != PlayerAnimation.State.jumping)  
        {
            playerAnimation.SetStateIdle();
        }
    }
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    private void OnDisable()
    {
        playerInputActions.Disable();
    }
}
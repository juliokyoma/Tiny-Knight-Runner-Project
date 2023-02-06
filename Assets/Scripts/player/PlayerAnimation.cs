using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    public enum State { idle, running, jumping, hurt, attacking }
    public State state;
    float num = Mathf.Sin(1);

    #region Player rotate walking variables
    [Header("Player Rotate Walking Animation")]
    [SerializeField] float n = 1;
    [SerializeField] bool leaningLeft = true;
    [SerializeField] bool leaningRight = false;
    [SerializeField] quaternion limit = new quaternion(0, 0, 1, 0);
    #endregion


    #region Intanciating
    private PlayerMovement playerMovement;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    #endregion
    private void Update()
    {
       
        if (GameManager.IsPlaying)
        { //se estiver jogando

            VelocityState();// verifica a velocidade 
           
        }
        //quaternion pos = transform.rotation;
        //pos.value.z = math.sin(1);
        //transform.rotation = pos;
        //transform.Rotate(0, 0, math.lerp(2f,2f,100f));
        // transform.Rotate(0,0,math.lerp(1f,1f,Mathf.Sin(1f)) );
        //PlayerRotateWalking(1f);
       
        

    }
    private void Start()
    {
        
    }

    private void VelocityState()
    {
        animator.SetInteger("State", (int)state); // atribui animações

        if (state == State.hurt)
        {

        }
        else if (state == State.attacking)
        {


        }
        else if (state == State.jumping)
        {
            

        }
        else if (state == State.running)
        {
            LearningWalking(0.1f, 0.03f);
        }
        else
        {
            state = State.idle;
        }

       

    }


    #region Flip animation
    public void FlipPlayerRight()
    {
        spriteRenderer.flipX = false;
    }
    public void FlipPlayerLeft()
    {
        spriteRenderer.flipX = true;
    }
    #endregion

    #region Hurt Animation
    public void ToggleSpriteRender()
    {
        if (spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }
    public void SetHurtAnimation()
    {
        for (float num = 0; num <= 1f; num += 0.2f)
        {
            this.Wait(num, (ToggleSpriteRender));
        }
    }
    #endregion

    #region Rotate Animation
    
    public void EnablePlayerRotate()
    {

    }

    public void PlayerRotate()
    {
        transform.Rotate(0, 0, math.lerp(2f, 2f, Mathf.Sin(1f)));
    }

    public void LearningWalking(float velocity, float amoutOfRotate)
    {
        

        if (leaningLeft == true)
        {
            print("learningleft");
            spriteRenderer.transform.Rotate(0,0, n);
            n = 0;
            n += velocity;
            if(transform.rotation.normalized.z >= amoutOfRotate)
            {
                leaningLeft = false;
                leaningRight= true;
            }
        }
        if (leaningRight == true)
        {
            print("learningright");
            n = 0;
            n -= velocity;
            spriteRenderer.transform.Rotate(0, 0, n);
            if (transform.rotation.normalized.z <= -amoutOfRotate)
            {
                leaningLeft = true;
                leaningRight = false;
            }
        }
        
    }
    #endregion


    public void SetStateIdle()
    {
        state = State.idle;
    }
}

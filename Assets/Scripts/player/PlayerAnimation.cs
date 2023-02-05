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
            animator.SetInteger("State", (int)state);// atribui anima��es
        }
        //quaternion pos = transform.rotation;
        //pos.value.z = math.sin(1);
        //transform.rotation = pos;
        //transform.Rotate(0, 0, math.lerp(2f,2f,100f));
        transform.Rotate(0,0,math.lerp(1f,1f,Mathf.Sin(1f)) );
    }

    private void VelocityState()
    {

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
        transform.Rotate(0, 0, math.lerp(2f, 2f, 100f));
    }
    public void PlayerRotateWalking(float degreesPerSecond)
    {
        Vector3 position = transform.position;
        bool leaningLeft = true;
        bool leaningRight = false;


        if (leaningLeft == true)
        {
            position.z += degreesPerSecond;
            if(position.z >= 3f)
            {
                leaningLeft = false;
                leaningRight= true;
            }
        }
        if (leaningRight == true)
        {
            position.z -= degreesPerSecond ;
            if (position.z <= -3f)
            {
                leaningLeft = true;
                leaningRight = false;
            }
        }
        transform.position = position;
    }
    #endregion

    public void SetStateIdle()
    {
        state = State.idle;
    }
}

using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Movement Variables
    [Header("Movement Variables")]
    public float playerSpeed = 5f;

    #endregion

    #region Jump Variables
    [Header("Jump Variables")]
    public bool isJumping;
    public float gravity;
    public Vector2 vector2;
    public float groundHeight = 2;
    public float jumpForce = 5f;
    public bool onGround = true; 

    public bool isHoldingJump;
    public float maxHoldingJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    #endregion

    [SerializeField] private LayerMask layerGround;

    #region Instancing

    private Rigidbody2D rigdbody2D; //variável do rigdbody que adiciona fisica na unity
    private BoxCollider2D boxCollider2D;
    public PlayerAnimation playerAnimation;

    void Awake()
    {
        rigdbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<PlayerAnimation>();

    }
    #endregion

    #region Events
    
    #endregion


    void Update()
    {
       
        

    }
        #region Jump Control
    private void FixedUpdate()
    {
        onGround = IsGrounded();
        Vector2 pos = transform.position;

        if (!onGround)
        {
            if(vector2.y > -50)
            {
                vector2.y += gravity * Time.fixedDeltaTime;
            }
          
            
        }
            pos.y += vector2.y * Time.fixedDeltaTime;
        if (isJumping)
        {


            if (vector2.y <= 0 && IsGrounded())
            {
                isJumping = false;
                playerAnimation.state = PlayerAnimation.State.idle;
            }
        }

            transform.position = pos;
    }
        #endregion


    #region Movement 
    public void PlayerJumpStarted(ref float force) // jump function
    {
        if (IsGrounded() || IsCloseToGround())
        {
            vector2.y = jumpForce;
            isJumping = true;
        }

        holdJumpTimer = 0;
        isHoldingJump = true;

        playerAnimation.state = PlayerAnimation.State.jumping;

         
    }
    public void PlayerJumpPerformed()
    {

    }
    public void PlayerJumpCanceled() 
    {
        isHoldingJump = false;
    }

    public void PlayerMove(float direction, ref float speed)
    {
        if (direction > 0)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            playerAnimation.state = PlayerAnimation.State.running;
        } else if (direction < 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            playerAnimation.state = PlayerAnimation.State.running;
        }
    }
    #endregion



    #region Collisions
    private bool IsGrounded()
    {
        RaycastHit2D ground = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.01f, layerGround);
        return ground.collider != null;
    }
    private bool IsCloseToGround()
    {
        RaycastHit2D ground = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 1f, layerGround);
        return ground.collider != null;
    }
    public void ResetJump()
    {
        IsGrounded();
    }
    #endregion





}



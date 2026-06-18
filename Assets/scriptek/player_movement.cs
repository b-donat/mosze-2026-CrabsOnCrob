using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Jump")]
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
   void Awake()
{
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
}

void Update()
{
    // ellenőrizzük hogy a földön vagyunk-e
    isGrounded = Physics2D.OverlapCircle(
        groundCheck.position,
        groundCheckRadius,
        groundLayer
    );

    // karakter irányának beállítása
    if (moveInput > 0)
    {
        spriteRenderer.flipX = false;
    }
    else if (moveInput < 0)
    {
        spriteRenderer.flipX = true;
    }

    // animációk kezelése
    Setanimation(moveInput);
}

    void FixedUpdate()
    {
        // horizontális mozgás
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    // input system MOVE hívja
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        moveInput = input.x;
    }

    // input system jump hívja
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }



/*----------animáció----------*/
    private void Setanimation(float moveInput)
    {
        /*földön mozdás*/
        if(isGrounded)
        {
            if(moveInput==0)
            {
                animator.Play("player_idle");
            }
            else
            {
                animator.Play("player_run");
            }
        }
        /*levegőbe mozgás*/
        else
        {
            if(rb.linearVelocity.y > 0)
            {
                animator.Play("player_jump");
            }
            else
            {
                animator.Play("player_fall");
            }
        }
    }
}
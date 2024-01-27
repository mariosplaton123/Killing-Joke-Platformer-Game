using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool isJumping;

    [Header("Knockback Parameters")]
    [SerializeField] private float KBforce;
    public float KBcounter;
    public float KBtotalTime;
    public bool KnockFromRight;

    private SpriteRenderer sprite;
    private Animator anim;
    private CapsuleCollider2D coll;

    private enum MovementState { Idle, Walk, Jump };
    private MovementState state = MovementState.Idle;
    private float dirX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Component references
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player input for horizontal movement
        dirX = Input.GetAxisRaw("Horizontal");

        // Check if the player is knocked back
        if (KBcounter <= 0)
        {
            // Move the player horizontally
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        }
        else
        {
            // Apply knockback force
            float knockbackDirection = KnockFromRight ? -1f : 1f;
            rb.velocity = new Vector2(knockbackDirection * KBforce, KBforce);
            KBcounter -= Time.deltaTime;
        }

        // Check for jump input and ground contact
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            
            
            // Apply vertical force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Update player animations
        isJumping = !IsGrounded();
        UpdateAnimations();     
        
    }

    // Check if the player is grounded using a BoxCast
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);

    }

    // Update player animations based on movement and velocity
    private void UpdateAnimations()
    {
        MovementState newState;

        // Determine movement state based on horizontal input
        if (dirX > 0)
        {
            newState = MovementState.Walk;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            newState = MovementState.Walk;
            sprite.flipX = true;
        }
        else
        {
            newState = MovementState.Idle;
        }

        // If the player is jumping, override the state
        if (isJumping)
        {
            newState = MovementState.Jump;
        }

        // Update animator parameter
        anim.SetInteger("state", (int)newState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private SpriteRenderer sprite;
    private Animator anim; 
    private CapsuleCollider2D coll;
    private enum MovementState {idle, walk, jump};
    private MovementState state = MovementState.idle;
    private float dirX = 0f;
    [SerializeField] private float KBforce;
    public  float KBcounter;
    public float KBtotalTime;
    public  bool KnockFromRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (KBcounter <=0){
            rb.velocity = new Vector2(dirX * speed,rb.velocity.y);
        }
        else{
            if(KnockFromRight == true){
                rb.velocity = new Vector2(-KBforce, KBforce);
            }
            if (KnockFromRight == false){
                rb.velocity = new Vector2(KBforce, KBforce);
            }
            KBcounter -= Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimations();
    }   

    private bool IsGrounded(){
     return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size , 0f, Vector2.down, .1f, jumpableGround);
    }


    private void UpdateAnimations(){
        MovementState state;
        if (dirX > 0){
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (dirX < 0){
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f){
            state = MovementState.jump;
        }

        anim.SetInteger("state",(int)state);
    }
}
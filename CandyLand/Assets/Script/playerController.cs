using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float checkRadius;
    private float moveInput;
    private bool facingRight = true;

    public bool isGrounded, isPlayerDrop, isPlayerDead;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask layerGround, layerDrop;

    private int extraJumps;
    public int extraJumpsValue;

    private Animator anim;
    

   public void Start()
    {
        anim = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layerGround);
        isPlayerDrop = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layerDrop);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Debug.Log("facing right = false");
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Debug.Log("facing left");
            Flip();
        }
        if (isGrounded == true) {
            extraJumps = extraJumpsValue;
            anim.SetBool("isJumping", false);

        }
      
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            anim.SetTrigger("takeOff");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", true);
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}

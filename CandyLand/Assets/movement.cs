using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public int playerSpeed, jumpSpeed;
    public bool facingRight = true, isGround = false;
    public float moveX;
    private Animator anim;

    void Update()
    {
        walk();
        jump();
    }

    void walk()
    {

        moveX = Input.GetAxis("Horizontal");
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void jump()
    {
        if (isGround)
        {
            if (Input.GetButtonDown("Vertical"))
            {
                Debug.Log("jump");
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
                isGround = false;
            }
        }
    }
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}

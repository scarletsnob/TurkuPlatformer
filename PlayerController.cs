using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    bool isJumping;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
	}

    void FixedUpdate()
    {
        float move = Input.GetAxis ("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        Jump();
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            isJumping = true;

            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

            rb.velocity = Vector2.zero;
        }
    }
}

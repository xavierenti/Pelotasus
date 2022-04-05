using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
    float xInput, yInput;

    Rigidbody2D rb;

    SpriteRenderer sp;

    public float jumpForce;
    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundlayer;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput * MoveSpeed, yInput * MoveSpeed, 0);

        PlatformerMove();
        FlipPlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);

    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(MoveSpeed * xInput, rb.velocity.y);
    }

    void FlipPlayer()
    {
        if(rb.velocity.x > -0.01f)
        {
            sp.flipX = true;
        }
        if(rb.velocity.x <  0.01f)
        {
            sp.flipX = false;
        }
    }

    private void OnColliderEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}

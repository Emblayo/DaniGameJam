using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;

    Rigidbody2D rigid;
    BoxCollider2D boxcol;
    float horizontal;
    float vertical;

    Vector2 rightVector = new Vector2(1f, 0f);
    Vector2 leftVector = new Vector2(-1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxcol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
        Debug.Log(IsGrounded());
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rigid.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Move(){
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(horizontalInput * speed, rigid.velocity.y);
    }

    private bool IsGrounded()
    {
        bool grounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
        return grounded;
    }



}


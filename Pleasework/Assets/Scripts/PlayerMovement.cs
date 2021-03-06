using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    [SerializeField] private float groundcheckRadius = 0.1f;
    public LayerMask playerLayer;

    Rigidbody2D rb;
    public Animator anim;
    float horizontal;

    [SerializeField] private int jumps;
    private int currentJumps;

    Vector2 rightVector = new Vector2(1f, 0f);
    Vector2 leftVector = new Vector2(-1f, 0f);

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        currentJumps = jumps;
        rb = GetComponent<Rigidbody2D>();

        if (anim == null) Debug.LogError("need to assign the animator in the inspector :)");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumps > 0) Jump();

        if (IsGrounded()) currentJumps = jumps;
        anim.SetBool("Grounded", IsGrounded());

        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
       if(canMove) Move();
    }

    void Jump()
    {
            //reset velocity first
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        currentJumps--;
    }

    void Move()
    {
        //apply movement
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        //flip character

        if (horizontal == 1) transform.rotation = new Quaternion(0, 0, 0, 0);
        if (horizontal == -1) transform.rotation = new Quaternion(0, -180, 0, 0);

        if (horizontal == 0) anim.SetBool("Running", false);
        else anim.SetBool("Running", true);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, groundcheckRadius, ~playerLayer);

        if (hit.collider == null) return false;

        return true;
    }

}


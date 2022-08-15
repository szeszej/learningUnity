using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK = "Walk";

    private bool isGrounded = true;
    private string GROUND = "Ground";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        //moving to the right
        if (movementX > 0)
        {
            anim.SetBool(WALK, true);
            sr.flipX = false;
        } else if (movementX < 0)
        {
            //going left
            anim.SetBool(WALK, true);
            sr.flipX = true;
        } else
        {
            //stahp!
            anim.SetBool(WALK, false);

        }
        
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
        }
    }
}

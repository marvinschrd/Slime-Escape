using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private float moveInput;

    private bool isGrounded;
    private bool isWalled;
    bool isDoored;
    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] LayerMask whatIsWall;
    [SerializeField] LayerMask whatIsDoor;
    [SerializeField] float checkRadius;

    private float jumpTimeCounter;
    [SerializeField] float jumpTime;
    private bool isJumping;

    Animator anim;
    [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isWalled = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsWall);
        isDoored = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsDoor);

        if (gameObject.tag == "Player")
        {
            if (isGrounded == true && Input.GetKeyDown(KeyCode.W) || isWalled == true && Input.GetKeyDown(KeyCode.W))
            {
                jumpSound.Play();
                anim.SetBool("isJumping", true);
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter = jumpTime;
                isJumping = true;
            }
        }

        if(gameObject.tag == "Player2")
        {
            if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow) || isWalled == true && Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpSound.Play();

                anim.SetBool("isJumping", true);
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter = jumpTime;
                isJumping = true;
            }
        }



        if (gameObject.tag == "Player")
        {

            if (Input.GetKey(KeyCode.W) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                    // Debug.Log(jumpTimeCounter);
                }
                else
                {
                    isJumping = false;
                }
            }
        }

        if (gameObject.tag == "Player2")
        {

            if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                    // Debug.Log(jumpTimeCounter);
                }
                else
                {
                    isJumping = false;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            anim.SetBool("isJumping", false);

        }
    }
}


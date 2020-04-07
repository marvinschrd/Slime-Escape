using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump2 : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private float moveInput;
    private bool isGrounded;
    [SerializeField] Transform feetPos;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float checkRadius;
    private float jumpTimeCounter;
    [SerializeField] float jumpTime;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
                Debug.Log(jumpTimeCounter);
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
    }
}


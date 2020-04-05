using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D body;
    Collider coll;
    Vector2 direction;
    [SerializeField] float jumpHeight;
    bool canJump = false;

    [SerializeField] float speed = 3;

    Animator anim;
    float horizontalSpeed;
    bool facingRight = false;
    bool facingLeft = true;
    private bool isMoving;
    [SerializeField] ParticleSystem particle;

    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider>();
        
    }

    enum State
    {
        IDLE,
        MOVING

    }

    State state = State.IDLE;

    // Update is called once per frame
    private void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("HorizontalPlayer2") * speed, body.velocity.y);
        horizontalSpeed = Input.GetAxis("HorizontalPlayer2");
        anim.SetFloat("speed", Mathf.Abs(horizontalSpeed));
       // jump();
        switch (state)
        {

            case State.IDLE:
                break;
            case State.MOVING:
                break;
        }
        if (horizontalSpeed < 0 && !facingLeft)
        {
            facingLeft = true;
            facingRight = false;
            anim.transform.Rotate(0, 180, 0);
        }
        if (horizontalSpeed > 0 && !facingRight)
        {
            facingRight = true;
            facingLeft = false;
            anim.transform.Rotate(0, 180, 0);
        }
        if (canJump)
        {
            particle.gameObject.SetActive(true);
        }
        if (!canJump)
        {
            particle.gameObject.SetActive(false);
        }  
    }
        void jump()
    {
        if (Input.GetKeyDown("up") && canJump)
        {
            jumpSound.Play();
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
            anim.SetBool("isJumping", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Player")
        {
            Debug.Log("canJump");
            canJump = true;
            anim.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
}
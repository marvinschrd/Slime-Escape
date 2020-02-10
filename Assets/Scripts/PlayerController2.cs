using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField] float jumpHeight;
    bool canJump = false;

    [SerializeField] float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        direction = new Vector2(Input.GetAxisRaw("HorizontalPlayer2") * speed, body.velocity.y);

        jump();
        switch (state)
        {
            case State.IDLE:
                break;
            case State.MOVING:
                break;
        }
    }

    void jump()
    {
        if (Input.GetKeyDown("up") && canJump)
        {
            body.velocity = new Vector2(body.velocity.x, jumpHeight);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground"|| collision.gameObject.tag == "Player")
        {
            Debug.Log("canJump");
            canJump = true;
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    float jumpHeight;
    bool canJump = false;
    float speed;
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
        direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        switch (state)
        {
            case State.IDLE:
                break;
            case State.MOVING:
                break;
        }
    }
}

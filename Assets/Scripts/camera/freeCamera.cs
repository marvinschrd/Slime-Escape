using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 cameraSafeZonePosition;
    Rigidbody2D body;
    bool canMove = false;
    Vector2 direction;
    float speed = 1;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cameraSafeZonePosition = transform.position;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
            Debug.Log("t");
            canMove = true;
        }
        if(canMove)
        {
            Debug.Log("move");
            direction = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        }
        if(canMove&&Input.GetKeyDown("q"))
        {
            transform.position = cameraSafeZonePosition;
            canMove = false;
        }
    }
}

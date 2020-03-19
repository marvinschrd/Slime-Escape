using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] float Speed = 50;
    bool canMove = false;
    Vector3 camStartPosition;
    bool canMoveCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        camStartPosition = transform.position;
    }

    enum State
    {
        NOT_MOVING,
        MOVING,
        GO_BACK
    }

    State state = State.NOT_MOVING;
    void Update()
    {

        switch (state)
        {
            case State.NOT_MOVING:
                if (Input.GetKeyDown("g") && canMoveCamera)
                {
                    Debug.Log("g");
                    //canMove = true;
                    camStartPosition = transform.position;
                    state = State.MOVING;
                }
                break;
            case State.MOVING:
                Debug.Log("moving");
                float xAxisValue = Input.GetAxis("Horizontal") * Speed;
                float zAxisValue = Input.GetAxis("Vertical") * Speed;

                transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + zAxisValue, transform.position.z);

                if (Input.GetKeyDown("h"))
                {
                    state = State.GO_BACK;
                }

                break;
            case State.GO_BACK:
                transform.position = camStartPosition;
                state = State.NOT_MOVING;
                break;
        }

    }
       

        // if(Input.GetKeyDown("g"))
        // {
        //     Debug.Log("g");
        //     canMove = true;
        // }
        // if(canMove)
        // {
        //     float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        //     float zAxisValue = Input.GetAxis("Vertical") * Speed;

        //     transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y + zAxisValue, transform.position.z);
        // }
        //if(canMove&&Input.GetKeyDown("h"))
        // {
        //     transform.position = camStartPosition;
        //     canMove = false;
        // }

    
public void Activate()
{
    canMoveCamera = true;
}
    public void Disable()
    {
        canMoveCamera = false;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    [SerializeField]GameObject upPosition;
    Vector3 initialPosition;
    Vector3 movePosition;
    bool activated = false;
    bool closed = false;

   
    // Start is called before the first frame update
    [SerializeField] AudioSource levelWinning;
    void Start()
    {
        initialPosition = transform.position;
        movePosition = upPosition.transform.position;
    }

    enum State
    {
        IDLE,
        OPENING,
        CLOSING
    }
    State state = State.IDLE;
    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case State.IDLE:

                break;
            case State.OPENING:
                if (gameObject.tag == "finalDoor")
                {
                    levelWinning.Play();
                }
                Open();
                break;
            case State.CLOSING:
                close();
                break;
        }
    }
     void Open()
    {
        transform.position = Vector3.Lerp(transform.position, movePosition, Time.deltaTime);  
    }
    public void Activate()
    {
        state = State.OPENING;
    }
    public void Closing()
    {
        state = State.CLOSING;
    }
    void close ()
    {
        transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
        if (transform.position.y - initialPosition.y < 0.1f)
        {
            state = State.IDLE;
        }
    }

    
}

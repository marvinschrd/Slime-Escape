using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoButtonsDoor : MonoBehaviour
{
    [SerializeField] GameObject upPosition;
    Vector3 initialPosition;
    Vector3 movePosition;
    bool activated = false;
    bool closed = false;
    bool fisrtButton = false;
    bool seconButton = false;
    int buttonsPressed = 0;
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
    void Update()
    {
        CheckButtons();
        switch (state)
        {
            case State.IDLE:

                break;
            case State.OPENING:
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
    void Activate()
    {
        if (gameObject.tag == "finalDoor")
        {
            if (levelWinning != null)
            {
                levelWinning.Play();
            }
        }
        state = State.OPENING;
    }
    void Closing()
    {
        state = State.CLOSING;
    }
    void close()
    {
        transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime);
        if (transform.position.y - initialPosition.y < 0.1f)
        {
            state = State.IDLE;
        }
    }

    void CheckButtons()
    {
        if (fisrtButton&&seconButton)
        {
            Activate();
        }
        else
        {
            Closing();
        }
    }

    public void Button1Pressed()
    {
        fisrtButton = true;
    }
    public void Button2Pressed()
    {
        seconButton = true; ;
    }

    public void Button1Unpressed()
    {
        fisrtButton = false;
    }
    public void Button2Unpressed()
    {
        seconButton = false;
    }
}

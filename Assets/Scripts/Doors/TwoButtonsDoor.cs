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
            levelWinning.Play();
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
        Debug.Log(buttonsPressed);
        if (buttonsPressed == 4)
        {
            Activate();
        }
        if(buttonsPressed <4)
        {
            Closing();
        }
    }

    public void ButtonPressed()
    {
        buttonsPressed++;
    }
    public void ButtonUnPressed()
    {
        buttonsPressed--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] door1 door;
    [SerializeField] TwoButtonsDoor twoButtonDoor;

    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Button")
        {
            Debug.Log("button");
            door.Activate();
        }
        if(gameObject.tag == "TwoButton")
        {
            twoButtonDoor.ButtonPressed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.tag == "Button")
        {
            door.Closing();
        }
        if (gameObject.tag == "TwoButton")
        {
            twoButtonDoor.ButtonUnPressed();
        }
    }
}

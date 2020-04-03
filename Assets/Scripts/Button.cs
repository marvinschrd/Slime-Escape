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
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Block")
        //{
        //    if (gameObject.tag == "Button")
        //    {
        //        Debug.Log("button");
        //        door.Activate();
        //    }
        //    if (gameObject.tag == "TwoButton")
        //    {
        //        twoButtonDoor.ButtonPressed();
        //    }
        //}
        if (gameObject.tag == "Button")
        {
            Debug.Log("button");
            door.Activate();
        }
        if (gameObject.tag == "Button1")
        {
            twoButtonDoor.Button1Pressed();
        }
        if (gameObject.tag == "Button2")
        {
            twoButtonDoor.Button2Pressed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Block")
        //{
        //    if (gameObject.tag == "Button")
        //    {
        //        door.Closing();
        //    }
        //    if (gameObject.tag == "TwoButton")
        //    {
        //        twoButtonDoor.ButtonUnPressed();
        //    }
        //}
        if (gameObject.tag == "Button")
        {
            door.Closing();
        }
        if (gameObject.tag == "Button1")
        {
            twoButtonDoor.Button1Unpressed();
        }
        if (gameObject.tag == "Button2")
        {
            twoButtonDoor.Button2Unpressed();
        }
    }
}

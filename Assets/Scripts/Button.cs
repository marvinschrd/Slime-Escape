using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] door1 door;
    [SerializeField] TwoButtonsDoor twoButtonDoor;
    SpriteRenderer sprite;
    private int i = 0;
    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player2" || other.tag == "Box")
        {
            GetDown();
        }
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
            sprite.color = Color.red;
            Debug.Log("button");
            door.Activate();
        }
        if (gameObject.tag == "Button1")
        {
            sprite.color = Color.red;

            twoButtonDoor.Button1Pressed();
        }
        if (gameObject.tag == "Button2")
        {
            sprite.color = Color.red;

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
        if (collision.tag == "Player" || collision.tag == "Player2" || collision.tag == "Box")
        {
            GetUp();
        }
        
        if (gameObject.tag == "Button")
        {
            sprite.color = Color.white;

            door.Closing();
        }
        if (gameObject.tag == "Button1")
        {
            sprite.color = Color.white;

            twoButtonDoor.Button1Unpressed();
        }
        if (gameObject.tag == "Button2")
        {
            sprite.color = Color.white;

            twoButtonDoor.Button2Unpressed();
        }
        
    }

    void GetUp()
    {
        Debug.Log("Im getting up");
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        if (i > 0)
        {
            i--;
            GetUp();
        }
    }
    void GetDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        if (i <= 5)
        {
            i++;
            GetDown();
        }
    }
}

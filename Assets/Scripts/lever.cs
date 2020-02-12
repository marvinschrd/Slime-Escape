using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    bool canActivate = false;
    [SerializeField] door1 door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate&&Input.GetKeyDown("e"))
        {
            Activate();
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player1"|| collision.gameObject.tag== "Player2")
        {
            canActivate = true;
        }
    }
    void Activate()
    {
        door.Activate();
    }
}

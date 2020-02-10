using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour
{
    [SerializeField]Camera mainCam;
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
        if(collision.gameObject.tag== "Player"&&collision.gameObject.tag=="Player2")
        {
            Debug.Log("okay");
            mainCam.transform.position = new Vector3(transform.position.x, transform.position.y, mainCam.transform.position.z);
        }
    }
}

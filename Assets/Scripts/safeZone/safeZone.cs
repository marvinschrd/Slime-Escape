using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safeZone : MonoBehaviour
{
    // Start is called before the first frame update
    cameraMover camera;
    void Start()
    {
        camera = FindObjectOfType<cameraMover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            camera.Activate();
        }
    }
}

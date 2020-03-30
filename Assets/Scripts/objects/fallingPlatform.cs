using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        float objectMass;
        Rigidbody2D objectBody;
        objectBody = collision.gameObject.GetComponent<Rigidbody2D>();
        objectMass = objectBody.mass;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;

    [SerializeField] private float speed;
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (up)
        {
            transform.Translate(Vector3.up*Time.deltaTime*speed);
        }
        if (down)
        {
            transform.Translate(Vector3.down*Time.deltaTime*speed);
        }
        if (left)
        {
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
        if (right)
        {
            transform.Translate(Vector3.right*Time.deltaTime*speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}

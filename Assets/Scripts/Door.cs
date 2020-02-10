using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    HingeJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        joint.useMotor = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door1 : MonoBehaviour
{
    [SerializeField]GameObject upPosition;
    bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            Open();
        }
    }
     void Open()
    {
        if(transform.position.y < upPosition.transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, upPosition.transform.position, Time.deltaTime);
        }
    }
    public void Activate()
    {
        activated = true;
    }
}

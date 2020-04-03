using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDispenser : MonoBehaviour
{

    [SerializeField] private bool up;
    [SerializeField] private bool down;
    [SerializeField] private bool left;
    [SerializeField] private bool right;

    [SerializeField] private GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",0,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Instantiate(arrow,new Vector3(transform.position.x,transform.position.y-1,transform.position.z),Quaternion.identity);
    }
}

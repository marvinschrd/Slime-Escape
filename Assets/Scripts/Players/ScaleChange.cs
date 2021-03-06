﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
   
    Vector3 growingScale = new Vector3(3.0f, 3.0f, 3.0f);
    Vector3 normalScale = new Vector3(1f, 1f, 1f);
    bool grow = false;
    float grownTimer;
    Rigidbody2D body;
    [SerializeField] float normalMass;
    [SerializeField] float bigMass;
     [SerializeField]float grownTime;
    [SerializeField] AudioSource growSound;
    [SerializeField] AudioSource shrinkSound;

    bool isBig = false;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    enum State
    {
        NORMAL_SIZE,
        GROWING,
        SHRINKING_BACK
    }

    State state = State.NORMAL_SIZE;
    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.NORMAL_SIZE:
                body.mass = normalMass;
                Debug.Log("normal");
                grownTimer = grownTime;
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    growSound.Play();
                    grow = true;
                state = State.GROWING;
                }
                isBig = false;
                break;
            case State.GROWING:
                Debug.Log("growing");
                body.mass = bigMass;
                Debug.Log(body.mass);
                Growing();
                if (transform.localScale.x >=2.9)
                {
                    grownTimer -= Time.deltaTime;
                    grow = false;
                }
                isBig = true;
                if(grownTimer<=0)
                {
                    shrinkSound.Play();
                    state = State.SHRINKING_BACK;
                }
                break;
            case State.SHRINKING_BACK:
                Debug.Log("shrinking");
                Shrinking();
                if(transform.localScale.x <=1.1f)
                {
                    state = State.NORMAL_SIZE;
                }
                break;
        }
    }

    public bool ShowState()
    {
        return isBig;
    }
   void Growing()
    {
        if (grow)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, growingScale, Time.deltaTime);
        }
    }
    void Shrinking()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, normalScale, Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakingPlatform : MonoBehaviour
{
    float currentMassLoad = 0;
    [SerializeField] float maximumLoad = 0;
    bool breaking = false;

    [SerializeField] float breakingTime = 0;
    float breakingTimer = 0;
    // Start is called before the first frame update

    BoxCollider2D collider;
    GameObject platform;
    Animator anim;
    void Start()
    {
        platform = gameObject;
        anim = gameObject.GetComponent<Animator>();
    }

    enum State
    {
        NORMAL,
        BREAKING,
        INVISIBLE
    }

    State state = State.NORMAL;

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.NORMAL:
                breakingTimer = breakingTime;
                CheckLoad();
                platform.SetActive(true);
                break;
            case State.BREAKING:
                anim.SetBool("goingToBreak", true);
                //DisablePlatform();
                state = State.INVISIBLE;
                break;
            case State.INVISIBLE:
                breakingTimer -= Time.deltaTime;
                if(breakingTimer<=0)
                {
                    anim.SetBool("goingToBreak", false);
                    state = State.NORMAL;
                }
                break;
        }
    }

    void CheckLoad()
    {
        if(currentMassLoad>maximumLoad)
        {
            state = State.BREAKING;
        }
    }

    void BreakPlatform()
    {
        if(breaking)
        {
            DisablePlatform();
        }
    }

    void DisablePlatform()
    {
        platform.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D objectBody;
        objectBody = collision.gameObject.GetComponent<Rigidbody2D>();
        currentMassLoad += objectBody.mass;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D objectBody;
        objectBody = collision.gameObject.GetComponent<Rigidbody2D>();
        currentMassLoad -= objectBody.mass;
    }
}

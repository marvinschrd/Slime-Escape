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
   // GameObject platform;
    SpriteRenderer sprite;
    Animator anim;
    void Start()
    {
        // platform = gameObject;
        collider = gameObject.GetComponent<BoxCollider2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
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

                // platform.SetActive(true);
                collider.enabled = true;
                sprite.enabled = true;
                breakingTimer = breakingTime;
                CheckLoad();
                break;
            case State.BREAKING:
                anim.SetBool("goingToBreak", true);
                state = State.INVISIBLE;
                break;
            case State.INVISIBLE:
                breakingTimer -= Time.deltaTime;
               // Debug.Log(breakingTimer);
                if(breakingTimer<=0)
                {
                    Debug.Log("setToFalse");
                    anim.SetBool("goingToBreak", false);
                    state = State.NORMAL;
                }
                break;
        }
        Debug.Log(state);
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
        // platform.SetActive(false);
        collider.enabled = false;
        sprite.enabled = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D objectBody;
        objectBody = collision.gameObject.GetComponent<Rigidbody2D>();
        currentMassLoad = objectBody.mass;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D objectBody;
        objectBody = collision.gameObject.GetComponent<Rigidbody2D>();
        currentMassLoad -= objectBody.mass;
    }
}

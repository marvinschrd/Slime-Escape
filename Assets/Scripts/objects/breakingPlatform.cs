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
    BoxCollider2D collider;
    SpriteRenderer sprite;
    Animator anim;
    void Start()
    {
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
    void Update()
    {
        switch(state)
        {
            case State.NORMAL:

                sprite.color = Color.white;
                collider.enabled = true;
                sprite.enabled = true;
                breakingTimer = breakingTime;
                CheckLoad();
                break;
            case State.BREAKING:
                sprite.color = Color.red;
                anim.SetBool("goingToBreak", true);
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

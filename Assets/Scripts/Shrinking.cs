using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinking : MonoBehaviour
{
    Vector3 shrinkingScale = new Vector3(0.3f, 0.3f, 0.3f);
    Vector3 normalScale = new Vector3(1f, 1f, 1f);
    bool shrink = false;
    float shrinkTimer;
    [SerializeField] float shrinkTime;

    [SerializeField] AudioSource shrinkSound;
    [SerializeField] AudioSource growSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    enum State
    {
        NORMAL_SIZE,
        SHRINKING,
        GROWING_BACK
    }

    State state = State.NORMAL_SIZE;

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.NORMAL_SIZE:
                Debug.Log("normal");
                shrinkTimer = shrinkTime;
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    shrinkSound.Play();
                   shrink = true;
                    state = State.SHRINKING;
                }
                break;
            case State.SHRINKING:
                Debug.Log("shrinking");
                Shrink();
                if (transform.localScale.x <= 0.35f)
                {
                    shrinkTimer -= Time.deltaTime;
                    shrink = false;
                }
                if (shrinkTimer <= 0)
                {
                    growSound.Play();
                    state = State.GROWING_BACK;
                }
                break;
            case State.GROWING_BACK:
                Debug.Log("growin back");
               Grow();
                if (transform.localScale.x >= 0.97f)
                {
                    state = State.NORMAL_SIZE;
                }
                break;
        }
    }
    void Shrink()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, shrinkingScale, Time.deltaTime);
    }
    void Grow()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, normalScale, Time.deltaTime);
    }
}

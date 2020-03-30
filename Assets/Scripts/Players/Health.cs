using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    Animator anim;
    SceneLoader sceneLoader;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Death()
    {
        anim.SetBool("isDead", true);
    }

    void ReloadScene()
    {
        sceneLoader.DeathReload();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="trap")
        {
            Death();
        }
    }

}

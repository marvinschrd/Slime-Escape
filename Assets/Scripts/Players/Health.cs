﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    Animator anim;
    string sceneName;
    Scene currentScene;

  
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Death()
    {
        Debug.Log("death");
        anim.SetBool("isDead", true);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="trap")
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "trap")
        {
            Death();
        }
    }
}

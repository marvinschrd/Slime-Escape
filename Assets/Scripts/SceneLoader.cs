using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    bool player1 = false;
    bool player2 = false;
    [SerializeField] String nextLevel;
    [SerializeField] String currentLevel;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject panelWin;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            player1 = true;
        }
        if(other.gameObject.tag=="Player2")
        {
            player2 = true;
        }
        if(player1&&player2)
        { 
        SceneManager.LoadScene(nextLevel);
        }
        //if(player1&&player2&&currentLevel=="scene3")
        //{

        //}
       // SceneManager.UnloadSceneAsync(currentLevel);
        _spriteRenderer.color=Color.red;
        panelWin.SetActive(true);
    }

    public void LoadLevel()
    {
        Debug.Log("I have been clicked ");
        SceneManager.LoadScene(nextLevel);
        SceneManager.UnloadSceneAsync(currentLevel);

    }
    

    
    
}

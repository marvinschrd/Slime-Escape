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
    [SerializeField] private string[] levels;
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
        SceneManager.LoadScene(levels[0]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(levels[1]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(levels[2]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(levels[3]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(levels[4]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(levels[5]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(levels[6]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene(levels[7]);
        SceneManager.UnloadSceneAsync(currentLevel);
    }
    
    
    

    
    
}

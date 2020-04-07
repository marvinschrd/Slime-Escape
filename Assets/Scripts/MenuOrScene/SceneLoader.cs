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
            _spriteRenderer.color=Color.red;
            SceneManager.LoadScene(nextLevel);
        }   
        panelWin.SetActive(true);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(levels[0]);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(levels[1]);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(levels[2]);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(levels[3]);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(levels[4]);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(levels[5]);
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene(levels[6]);
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene(levels[7]);
    }
    public void LoadLevel9()
    {
        SceneManager.LoadScene(levels[8]);
    }
    public void LoadLevel10()
    {
        SceneManager.LoadScene(levels[9]);
    }
    public void LoadLevel11()
    {
        SceneManager.LoadScene(levels[10]);
    }
    public void LoadLevel12()
    {
        SceneManager.LoadScene(levels[11]);
    }
    
    
    
    
    

    
    
}

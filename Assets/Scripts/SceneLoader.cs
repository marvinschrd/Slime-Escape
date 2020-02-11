using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] String nextLevel;
    [SerializeField] String currentLevel;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextLevel);
        SceneManager.UnloadSceneAsync(currentLevel);
        _spriteRenderer.color=Color.red;
        
    }
    
    
    
    
}

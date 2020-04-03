using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] GameObject panelMenuPause;
    [SerializeField] GameObject panelMenuWin;
    [SerializeField] GameObject panelMainMenu;
    [SerializeField] String reloadScene;
    [SerializeField] String mainMenuScene;

    Scene currentScene;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        reloadScene = currentScene.name;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelMenuPause.activeSelf)
            {
                UnloadMenuPause();
            }
            else
            {
                LoadMenuPause();
            }
        }
        
        ////////////
        /// Make win condition
        ////////////
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 0;
    }
    public void UnloadMainMenu()
    {
        panelMainMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void LoadMenuPause()
    {
        panelMenuPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnloadMenuPause()
    {
        panelMenuPause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadMenuWin()
    {
        panelMenuWin.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void Retry()
    {
        SceneManager.LoadScene(reloadScene);
    }
}
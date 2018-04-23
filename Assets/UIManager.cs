using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    GameObject[] menuObjects;
    public Text scoreText;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        menuObjects = GameObject.FindGameObjectsWithTag("Menu");
        hideMenu();
    }
   public void SetScore(int score) { 
        scoreText.text = "Score: " + score;
    }

    //Reloads the Level
    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GamePaused()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showMenu();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hideMenu();
        }
    }

    public void showMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
           obj.SetActive(true);
        }
    }

    public void hideMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showMenu();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hideMenu();
            }
        }
}
}

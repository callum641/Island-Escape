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
        HideMenu();
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
            ShowMenu();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HideMenu();
        }
    }

    public void ShowMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
           obj.SetActive(true);
        }
    }

    public void HideMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(false);
        }
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                ShowMenu();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HideMenu();
            }
        }
}
}

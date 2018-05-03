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
    //exits the game
    public void ExitGame()
    {
        Application.Quit();
    }
    //returns to main menu
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    //brigns up objects with the menu tag
    public void GamePaused()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowMenu();
        }
        //hides objects with menu tag
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            HideMenu();
        }
    }
    //sets all objects eith the menu tag to active
    public void ShowMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
           obj.SetActive(true);
        }
    }
    //sets all objects with the menu tag to deactive
    public void HideMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(false);
        }
    }
    //loads the instructiosn scene
    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    // Update is called once per frame
    void Update () {

        //sets menu to active or deactive on keypress
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

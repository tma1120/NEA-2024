using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;//pause menu panel
    public bool isPaused;

    void start()
    {
        pauseMenu.SetActive(false);//sets pause menu inactive
        isPaused = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))//if escape key is pressed
        {
            if(isPaused)
            {
                ResumeGame();//if game is paused, resume
            }
            else
            {
                PauseGame();//if game isnt paused, resume
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);//set pause menu active
        Time.timeScale = 0f;//freeze in game time
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);//set pause menu inactive
        Time.timeScale = 1;//freeze in game time
        isPaused = false;
    }

    public void exitGame()
    {
        SceneManager.LoadScene(0);//load the main menu scene
    }     
}



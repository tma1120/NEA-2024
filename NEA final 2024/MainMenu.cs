using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()     
    {
        SceneManager.LoadScene(1); // loads the main game scene
    }

    public void quitGame()
    {
        Application.Quit();// quits the application
    }
}

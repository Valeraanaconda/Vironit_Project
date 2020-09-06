using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continueButton, resetButton;

    private void Start()
    {
        if (File.Exists("E:/" + "Save.txt")) 
        {
            continueButton.SetActive(true);
            resetButton.SetActive(true);
        }
    }
    public void PlayNewGame() 
    {
        File.Delete("E:/" + "Save.txt");
        SceneManager.LoadScene("Game");
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ResetProgress()
    {
        File.Delete("E:/" + "Save.txt");
        SceneManager.LoadScene("Main Menu");
    }


    public void QuitGame() 
    {
        Application.Quit();
    }
    
}

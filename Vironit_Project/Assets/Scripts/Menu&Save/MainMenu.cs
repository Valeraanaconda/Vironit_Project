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
        if (File.Exists(Application.dataPath + "Save.txt")) 
        {
            continueButton.SetActive(true);
            resetButton.SetActive(true);
        }
    }
    public void PlayNewGame() 
    {
        File.Delete(Application.dataPath + "Save.txt");
        PlayerPrefs.DeleteKey("seconds");
        PlayerPrefs.DeleteKey("minutes");
        PlayerPrefs.DeleteKey("hours");
        PlayerPrefs.DeleteKey("timer");
        PlayerPrefs.DeleteKey("DayTime");
        PlayerPrefs.DeleteKey("SunIntencity");
        PlayerPrefs.DeleteKey("MoonIntencity");
        SceneManager.LoadScene("Game");
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ResetProgress()
    {
        File.Delete(Application.dataPath + "Save.txt");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main Menu");
    }


    public void QuitGame() 
    {
        Application.Quit();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameIsPaused) 
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }
    // Возможно добавлю кнопку для возвращения в главное меню
    public void Resume() 
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }
    void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}

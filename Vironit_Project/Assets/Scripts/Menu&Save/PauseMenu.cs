using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
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

        Cursor.visible = true;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }
    void Pause()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
}

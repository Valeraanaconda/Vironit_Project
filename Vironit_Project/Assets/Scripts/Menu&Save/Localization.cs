using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Localization : MonoBehaviour
{
    public void Language_Rus()
    {
        string language = "Rus";
        PlayerPrefs.SetString("Language", language);
        SceneManager.LoadScene("Main Menu");
    }
    public void Language_Eng()
    {
        string language = "Eng";
        PlayerPrefs.SetString("Language", language);
        SceneManager.LoadScene("Main Menu");
    }
}

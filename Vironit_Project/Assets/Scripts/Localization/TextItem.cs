using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextItem : MonoBehaviour
{
    Text text;
    private string getLanguage;
    // Две публичные переменные для хранения перевода
    public string textRus;
    public string textEng;
    private void Start()
    {
        text = GetComponent<Text>();
        getLanguage = PlayerPrefs.GetString("Language");
        if (getLanguage == "Eng" || getLanguage == "")
        {  
            text.text = textEng;
        }

        else if (getLanguage == "Rus")
        {
            text.text = textRus;
        }
    }
}

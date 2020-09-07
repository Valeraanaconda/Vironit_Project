using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    private Button saveButton;
    private InputField inputText;

    private void Start()
    {
        inputText = GameObject.Find("FileRedactor").GetComponent<InputField>();
        saveButton = GetComponent<Button>();

        if (inputText.text != null)
        {
            inputText.text = PlayerPrefs.GetString("readme");
        }

        saveButton.onClick.AddListener(Save);
    }

    private void Save()
    {
        PlayerPrefs.SetString("readme", inputText.text);
    }
}


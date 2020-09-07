using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public GameObject textPanel, windowsPanel;
    private Button quitButton;
    void Start()
    {
        quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(Quit);
    }

    public void Quit() 
    {
        textPanel.SetActive(false);
        windowsPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerButton : MonoBehaviour
{
    private Button powerButton;
    public GameObject textPanel;

    void Start()
    {
        powerButton = GetComponent<Button>();
        powerButton.onClick.AddListener(PowerOn);
    }

    public void PowerOn() 
    {
        if (textPanel.activeSelf) 
        {
            textPanel.SetActive(false);
        }

        else if (!textPanel.activeSelf) 
        {
            textPanel.SetActive(true);
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SafeController : MonoBehaviour
{
    public Animator safe_anim;

    public bool usable_safe;
    public string password;
    public string input_Value;
    public Text displayed_text;
    public GameObject safe_panel;

    void Start()
    {
        safe_anim = GetComponent<Animator>();
        usable_safe = false;
        password += "1234";
    }

    private void Update()
    {
        if (usable_safe == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }

    }

    public void AddValue(string number)
    {
        input_Value += number;
        displayed_text.text = input_Value;
    }
    public void EnterButton()
    {

        if (input_Value == password)
        {
            usable_safe = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            safe_panel.SetActive(false);
            safe_anim.SetBool("isOpen", true);
        }
        else
        {
            Debug.Log("work");
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            safe_panel.SetActive(false);
            usable_safe = false;
            input_Value = "";
            displayed_text.text = input_Value;
        }

    }
    public void ClearText()
    {
        input_Value = "";
        displayed_text.text = input_Value;
    }
}

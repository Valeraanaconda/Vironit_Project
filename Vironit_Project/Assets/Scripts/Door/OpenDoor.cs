﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public bool IsOpen = false;
    public Animator open_door;
    void Start()
    {
        open_door = GetComponent<Animator>();
    }

    public void openDoor()
    {
        IsOpen = !IsOpen;
        open_door.SetBool("IsOpen", IsOpen);
        StartCoroutine("LoadScene");
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}

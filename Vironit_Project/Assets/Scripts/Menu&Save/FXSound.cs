using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSound : MonoBehaviour
{
    public AudioSource clickFX;
    public AudioClip buttonClick;
    public void ButtonClick() 
    {
        clickFX.PlayOneShot(buttonClick);
    }
}

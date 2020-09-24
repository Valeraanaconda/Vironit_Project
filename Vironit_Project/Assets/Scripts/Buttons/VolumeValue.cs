using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    public Slider slider;
    public void ChangeVol()
    {
        AudioListener.volume = slider.value;
    }
}

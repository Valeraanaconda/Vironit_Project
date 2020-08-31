using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
   public Slider volumeSlider;
   public void SaveMenuOptions() 
    {
        PlayerPrefs.SetFloat("Slider Value", volumeSlider.value);
    }
  
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value= PlayerPrefs.GetFloat("Slider Value");
    }
}

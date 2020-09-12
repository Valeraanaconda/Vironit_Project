using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text second;
    public Text minutes;
    public Text hours;
   
    void Update()
    {
        second.text = "" + PlayerPrefs.GetFloat("seconds");
        minutes.text = "" + PlayerPrefs.GetFloat("minutes") + " :";
        hours.text = "" + PlayerPrefs.GetFloat("hours") + " :";
    }
}
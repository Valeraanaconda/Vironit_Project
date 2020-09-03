using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float timer;
    private float seconds;
    private float minutes1 = 10.0f;
    private float hours1 = 12.0f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("seconds"))
        {
            seconds = PlayerPrefs.GetFloat("seconds");
            minutes1 = PlayerPrefs.GetFloat("minutes");
            hours1 = PlayerPrefs.GetFloat("hours");
            timer = PlayerPrefs.GetFloat("timer");
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            timer = 0.0f;
            seconds++;
        }

        if (seconds >= 60)
        {
            minutes1++;
            seconds = 0;
        }

        if (minutes1 >= 60)
        {
            hours1++;
            minutes1 = 0;
        }

        if (hours1 > 24)
        {
            hours1 = 0;
        }

        PlayerPrefs.SetFloat("seconds", seconds);
        PlayerPrefs.SetFloat("minutes", minutes1);
        PlayerPrefs.SetFloat("hours", hours1);
        PlayerPrefs.SetFloat("timer", timer);
    }
}

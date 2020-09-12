using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{

    [Range(0, 1)] public float TimeOfDay;
    public float DayDuration = 300f;

    public AnimationCurve SunCurve;
    public AnimationCurve MoonCurve;
    public AnimationCurve SkyBoxCurve;

    public ParticleSystem Stars;

    public Material Day;
    public Material Night;

    public Light Sun;
    public Light Moon;

    private float sunIntensity;
    private float moonIntensity;

    void Start()
    {
        if (PlayerPrefs.HasKey("DayTime")) 
        {
            TimeOfDay=PlayerPrefs.GetFloat("DayTime");
            sunIntensity = PlayerPrefs.GetFloat("SunIntencity");
            moonIntensity = PlayerPrefs.GetFloat("MoonIntencity");
        }
        sunIntensity = Sun.intensity;
        moonIntensity = Moon.intensity;
    }

    
    void Update()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) TimeOfDay -= 1;
        PlayerPrefs.SetFloat("DayTime", TimeOfDay);

        RenderSettings.skybox.Lerp(Night,Day, SkyBoxCurve.Evaluate(TimeOfDay));
        RenderSettings.sun = SkyBoxCurve.Evaluate(TimeOfDay) >= 0.1f ? Sun : Moon;
        DynamicGI.UpdateEnvironment();

        var mainModule = Stars.main;
        mainModule.startColor = new Color(1, 1, 1, 1-SkyBoxCurve.Evaluate(TimeOfDay));

        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);
        Moon.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f+180f, 180, 0);

        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
        PlayerPrefs.SetFloat("SunIntencity", Sun.intensity);

        Moon.intensity = moonIntensity * MoonCurve.Evaluate(TimeOfDay);
        PlayerPrefs.SetFloat("MoonIntencity", Moon.intensity);

    }
}

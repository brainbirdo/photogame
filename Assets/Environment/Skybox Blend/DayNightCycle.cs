using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{
    public Material skybox;
    public float timeOfDay;
    public float transitionDuration;

    public Light sunLight;

    private float timer;


    Color dayColor = new Color(0.86f, 0.70f, 0.55f, 1);
    Color nightColor = new Color(0.38f, 0.40f, 0.49f, 255);

    void Start()
    {
        timer = 0;
        if (skybox != null && transitionDuration > 0)
        {
            timeOfDay = Mathf.Clamp(timeOfDay, 0, 1);
            skybox.SetFloat("_CubemapTransition", timeOfDay);
        }
    }
    void Update()
    {



        timer += Time.deltaTime;

        // Calculate the current time as a value between -1 and 1
        float t = Mathf.Sin(timer / transitionDuration * Mathf.PI * 2);

        // Scale the value of t to the range [0, 1]
        t = (t + 1) / 2;

        // Use Mathf.Lerp to smoothly transition between 0 and 1
        timeOfDay = Mathf.Lerp(0, 1, t);
        skybox.SetFloat("_CubemapTransition", timeOfDay);

        sunLight.color = Color.Lerp(dayColor, nightColor, timeOfDay);


        // Reset the timer if the transition is complete
        if (timer >= transitionDuration)
        {
            timer -= transitionDuration;
        }
    }
}

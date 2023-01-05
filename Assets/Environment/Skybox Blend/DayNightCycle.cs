using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material skybox;
    public float timeOfDay;
    public float transitionDuration;

    private float timer;

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

        // Reset the timer if the transition is complete
        if (timer >= transitionDuration)
        {
            timer -= transitionDuration;
        }
    }
}

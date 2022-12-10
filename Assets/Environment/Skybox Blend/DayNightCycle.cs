using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material skybox;
    public float timeOfDay;
    void Update()
    {
        timeOfDay = Mathf.PingPong(Time.time, 1.0f);
        skybox.SetFloat("_CubemapTransition", timeOfDay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{

    public WeatherDetection weatherDetection; // For checking isRainy and isFoggy bools

    public GameObject rainSystem;
    public GameObject fogSystem;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void WeatherCalling()
    {
        if (!weatherDetection.isRainy && !weatherDetection.isFoggy)
        {
            // If there's no weather, start the weather cycle.
            RainOn();
        }

        else
        {
            if (!weatherDetection.isRainy)
            {
                if (!weatherDetection.isFoggy)
                {
                    FogOn();
                }
                else if (weatherDetection.isFoggy)
            {
                    FogOff();
                }
            }

            if (!weatherDetection.isFoggy)
            {
                if (!weatherDetection.isRainy)
                {
                    RainOn();
                }
                else if (weatherDetection.isRainy)
                {
                    RainOff();
                }
            }
        }
    }

    void FogOn()
    {
        weatherDetection.isFoggy = true;
        fogSystem.SetActive(true);
    }

    void FogOff()
    {
        weatherDetection.isFoggy = false;
        fogSystem.SetActive(false);
    }

    void RainOn()
    {
        weatherDetection.isRainy = true;
        rainSystem.SetActive(true);
    }

    void RainOff()
    {
        weatherDetection.isRainy = false;
        rainSystem.SetActive(false);
    }
}

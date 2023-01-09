using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{

    public WeatherDetection weatherDetection; // For checking isRainy and isFoggy bools

    public GameObject rainSystem;

    private System.Random random;

    void Start()
    {
        ClearSkies();
        
        random = new System.Random();
        InvokeRepeating("GenerateRandomNumber", 60, 60);
    }

    void GenerateRandomNumber()
    {
        // Generate a random number between 0 and 2.
        int randomNumber = random.Next(0, 3);

        // Invoke a different method based on the random number.
        switch (randomNumber)
        {
            case 0:
                Debug.Log("0");
                ClearSkies();
                break;
            case 1:
                Debug.Log("1");
                RainOn();
                break;
            case 2:
                Debug.Log("2");
                FogOn();
                break;
        }
    }

    void ClearSkies()
    {
        Debug.Log("Clear Skies");
        weatherDetection.isRainy = false;
        weatherDetection.isFoggy = false;
        RenderSettings.fogDensity = 0f;
        rainSystem.SetActive(false);
    }

    void RainOn()
    {
        if (!weatherDetection.isRainy)
        {
            Debug.Log("Rain On");
            weatherDetection.isRainy = true;
            weatherDetection.isFoggy = false;
            RenderSettings.fogDensity = 0f;
            rainSystem.SetActive(true);
        }
    }

    void FogOn()
    {
        if (!weatherDetection.isFoggy)
        {
            Debug.Log("Fog On");
            weatherDetection.isFoggy = true;
            weatherDetection.isRainy = false;
            RenderSettings.fogDensity = 0.24f;
            rainSystem.SetActive(false);
        }
    }



}

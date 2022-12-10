using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherDetection : MonoBehaviour
{
    [Header("Weather Checks")]
    public bool isDaytime;
    public bool isRainy;
    public bool isFoggy;

    public GameObject night;
    public GameObject day;
    public GameObject rainy;
    public GameObject foggy;

    public GameObject WeatherParameters;

    public PhotoCapture photoCapture;

    [Header("Taken Photo Data")]
    public bool dayCaptured;
    public bool rainCaptured;
    public bool clearCaptured;
    public bool fogCaptured;


    void Update()
    {

        /// Whichever has been captured will be shown
        if (photoCapture.viewingPhoto)
        {
            WeatherParameters.SetActive(true);
            CapturedWeatherIcons();
        }

        else if (photoCapture.checkingPhoto)
        {
            WeatherParameters.SetActive(true);
        }

        else
        {
            WeatherParameters.SetActive(false);
        }
    }

    void CapturedWeatherIcons()
    {
        /// Checks which weather was captured and displays their icon.
        if (dayCaptured == true)
        {
            day.SetActive(true);
            night.SetActive(false);
        }
        if (dayCaptured == false)
        {
            night.SetActive(true);
            day.SetActive(false);
        }

        if(rainCaptured == true)
        {
            rainy.SetActive(true);
            foggy.SetActive(false);
        }

        if(fogCaptured == true)
        {
            foggy.SetActive(true);
            rainy.SetActive(false);
        }

        if(clearCaptured == true)
        {
            foggy.SetActive(false);
            rainy.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int NPC1 = 0;
    public int NPC2 = 0;
    public int NPC3 = 0;

    public ObjectDetector objectDetector;
    public WeatherDetection weatherDetection;

    void Start()
    {
        objectDetector = GetComponent<ObjectDetector>();
    }


    public void ScoreReset()
    {
        NPC1= 0;
        NPC2= 0;
        NPC3 = 0;
    }

    public void ScoreCheck()
    {
        NPC1Check();
    }

    public void NPC1Check()
    {
        if (objectDetector.objectsInView.Exists(x => x.name == "Pinhole Mountains"))
        {
            NPC1 = +1;
        }

        if (weatherDetection.dayCaptured)
        {
            NPC1= +1;
        }

        if (weatherDetection.rainCaptured)
        {
            NPC1 = -1;
        }
    }
}

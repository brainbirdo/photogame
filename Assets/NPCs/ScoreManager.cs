using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public Flowchart flowchart;
    public int NPC1 = 0;
    public int NPC2 = 0;
    public int NPC3 = 0;

    public ObjectDetector objectDetector;
    public WeatherDetection weatherDetection;

    void Start()
    {
        objectDetector = GetComponent<ObjectDetector>();
    }

    void Update()
    {
        flowchart.SetIntegerVariable("NPC1", NPC1);
        flowchart.SetIntegerVariable("NPC2", NPC2);
        flowchart.SetIntegerVariable("NPC3", NPC3);
    }

    public void ScoreReset()
    {
        Debug.Log("Reset");
        NPC1 = 0;
        NPC2 = 0;
        NPC3 = 0;
    }

    public void ScoreCheck()
    {
        NPC1Check();
        NPC2Check();
        NPC3Check();
    }

    public void NPC1Check()
    {
        // Old. Likes sun, sea, and sand. 
        // Perfect score is 2. Daytime, no rain, of water.
        Debug.Log("NPC1Check");

        if (objectDetector.objectsInView.Exists(x => x.name == "Daguerro's River"))
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

    public void NPC2Check()
    {
        // Mysterious. Likes moody photos of the forest.
        // Perfect score is 2. Foggy Mountains.
        Debug.Log("NPC2Check");

        if (objectDetector.objectsInView.Exists(x => x.name == "Obscura Forest"))
        {
            NPC2 = +1;
        }

        if (weatherDetection.fogCaptured)
        {
            NPC2 = +1;
        }

        if (weatherDetection.rainCaptured)
        {
            NPC2 = -1;
        }
    }

    public void NPC3Check()
    {
        // Complicated. Likes nighttime rain Mountains, dislikes clear weather and daytime.
        // Perfect score is 3. Foggy night Mountains. 
        Debug.Log("NPC3Check");

        if (objectDetector.objectsInView.Exists(x => x.name == "Pinhole Mountains"))
        {
            NPC3 = +1;
        }

        if (weatherDetection.fogCaptured)
        {
            NPC3 = +1;
        }

        if (!weatherDetection.dayCaptured)
        {
            NPC3 = +1;
        }

        if (weatherDetection.clearCaptured)
        {
            NPC3 = -1;
        }

        if (weatherDetection.dayCaptured)
        {
            NPC3 = -1;
        }
    }
}

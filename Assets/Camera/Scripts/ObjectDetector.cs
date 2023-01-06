using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectDetector : MonoBehaviour
{
    public List<GameObject> objectsInView;
    private List<InCameraDetector> detectors;
    public TextMeshProUGUI textElement;


    void Start()
    {
        detectors = new List<InCameraDetector>();
        InCameraDetector[] allDetectors = FindObjectsOfType<InCameraDetector>();
        foreach (InCameraDetector detector in allDetectors)
        {
            detectors.Add(detector);
        }
    }

    public void ObjectDetect()
    {
        objectsInView = new List<GameObject>();
        foreach (InCameraDetector detector in detectors)
        {
            if (detector.isInView)
            {
                objectsInView.Add(detector.gameObject);
            }
        }


        string objectList = "Greetings from ";
        if (objectsInView.Count > 0)
        {
            objectList += objectsInView[0].name + "!";
        }
        textElement.text = objectList;
    }
}

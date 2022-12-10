using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material skybox;

    void Start()
    {
        skybox.SetRange("_CubemapTransition", 0);

    }

    void Update()
    {
        skybox.SetRange("_CubemapTransition", 1);
    }
}

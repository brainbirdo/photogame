using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material skybox;

    void Start()
    {
        skybox.SetFloat("_CubemapTransition", 0);

    }

    void Update()
    {
        skybox.SetFloat("_CubemapTransition", 1);
    }
}

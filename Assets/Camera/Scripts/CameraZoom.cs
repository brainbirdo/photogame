using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoom : MonoBehaviour
{
 public float minFov = 15f;
 public float maxFov = 40f;
 public float Fov;
 public float sensitivity = 10f;
 public Camera cam;

 public bool canZoom;
 
void Update()
    {
        if (canZoom)
        {
            float Fov = cam.fieldOfView;
            Fov += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
            Fov = Mathf.Clamp(Fov, minFov, maxFov);
            cam.fieldOfView = Fov;
        }
        if (!canZoom)
        {
            cam.fieldOfView = 40;
        }
    }
}

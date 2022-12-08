using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
 public float minFov = 15f;
 public float maxFov = 40f;
 public float Fov;
 public float sensitivity = 10f;
 public CinemachineVirtualCamera vcam;

 public bool canZoom;
 
void Update()
    {
        if (canZoom)
        {
            Fov = Camera.main.fieldOfView;
            Fov += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
            Fov = Mathf.Clamp(Fov, minFov, maxFov);
            vcam.m_Lens.FieldOfView = Fov;
        }
        if (!canZoom)
        {
            Fov = 40f;
        }
    }
}

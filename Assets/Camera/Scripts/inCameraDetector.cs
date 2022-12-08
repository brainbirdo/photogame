//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Cinemachine;

//public class InCameraDetector : MonoBehaviour
//{
//    CinemachineVirtualCamera vcam;
//    MeshRenderer renderer;
//    Plane[] cameraFrustum;
//    Collider collider;

//    void Start()
//    {
//        vcam = vcam.m_Follow;
//        renderer = GetComponent<MeshRenderer>();
//        collider = GetComponent<Collider>();
//    }


//    void Update()
//    {
//        var bounds = collider.bounds;
//        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(vcam);
//        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
//        {
//            Debug.Log("Captured by Camera");
//        }
//        else
//        {
//            Debug.Log("Nothing in View");
//        }
//    }
//}

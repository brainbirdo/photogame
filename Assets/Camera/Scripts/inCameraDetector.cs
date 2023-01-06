using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    public Camera myCamera;
    public MeshRenderer myRenderer;
    Plane[] cameraFrustum;
    public Collider myCollider;
    public bool isInView;

    void Update()
    {
        var bounds = myCollider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(myCamera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            isInView = true;
        }
        else
        {
            isInView = false;
        }
    }
}

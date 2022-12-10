using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCameraDetector : MonoBehaviour
{
    public Camera myCamera;
    public MeshRenderer myRenderer;
    Plane[] cameraFrustum;
    public Collider myCollider;

    // Update is called once per frame
    void Update()
    {
        var bounds = myCollider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(myCamera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            Debug.Log("Object in view of camera");
            // If in view & photo has been taken, set score to XYZ. 
        }
        else
        {
            Debug.Log("Nothing");
        }

    }
}

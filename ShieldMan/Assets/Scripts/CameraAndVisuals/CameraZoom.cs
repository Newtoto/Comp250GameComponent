using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CameraZoom : MonoBehaviour
{
    
    float currentFOV;
    [CustomEditorHeaders("Things for designers to change", 10,100,200,0,0.5f)]
    public float maxCamDistance;
    public float maxFOV;
    public float initFOV;
    public float fovSpeed = 1f;

    Camera cam;

    public float velocityChange;

    Rigidbody2D rb2d;

   //Reset the size/FOV
    private void ResetFOV()
    {
        cam.orthographicSize = initFOV;
    }
    //Getting components and the FOV to revert to
    private void Start()
    {
        cam = GetComponent<Camera>();
        initFOV = cam.orthographicSize;
        rb2d = GetComponentInParent<Rigidbody2D>();
    }
    //Actually changing zooms
    private void LateUpdate()
    {
        if (rb2d.velocity.magnitude > velocityChange)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxFOV, Time.deltaTime * fovSpeed);
        } else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, initFOV, Time.deltaTime * fovSpeed);
        }
    }

}


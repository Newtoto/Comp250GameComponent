using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFovOnCol : MonoBehaviour {

    public Camera playerCam;

    float oldFov;
    public float newFov;

    bool camZoom = false;

	// Use this for initialization
	void Start ()
    {
        oldFov = playerCam.orthographicSize;
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D ()
    {
        Debug.LogWarning("wannker");
        //playerCam.orthographicSize = newFov;

        camZoom = true;


    }

    void OnTriggerExit2D()
    {
        //playerCam.orthographicSize = oldFov;
        camZoom = false;
    }

    private void LateUpdate()
    {
        if (camZoom)
        {            
            playerCam.orthographicSize = Mathf.Lerp(playerCam.orthographicSize, newFov, Time.deltaTime * 10);
        } else
        {
            playerCam.orthographicSize = Mathf.Lerp(playerCam.orthographicSize, oldFov, Time.deltaTime * 10);
        }
    }
}

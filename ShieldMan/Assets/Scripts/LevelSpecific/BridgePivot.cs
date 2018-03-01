using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePivot : MonoBehaviour {

    private bool opening;

	// Update is called once per frame
	void Update ()
    {
        Debug.Log(transform.localEulerAngles.z);

        if (transform.localEulerAngles.z < 91)
        {
            opening = true;
        }
        else if (transform.localEulerAngles.z > 180)
        {
            opening = false;
        }


        if (opening)
        {
            transform.Rotate(new Vector3(0, 0, 1));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -1));
        }

	}
}

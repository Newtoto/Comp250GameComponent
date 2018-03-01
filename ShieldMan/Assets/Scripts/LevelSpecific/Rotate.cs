using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool clockwise;
    int direction;
    public float speed = 1;
	// Use this for initialization
	void Start ()
    {
        if (clockwise == true)
        {
            direction = -2;
        }
        else {
            direction = 2;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, direction) * speed);
    }
}

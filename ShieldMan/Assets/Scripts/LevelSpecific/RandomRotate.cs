using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    
    public float minRange, maxRange;

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
        float rand = Random.Range(0, 1.5f);
        if (rand < 1)
        {
            rand = 1;
        }
        transform.Rotate(new Vector3(0, 0, direction) * rand);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyVillager : MonoBehaviour 
{
	public GameObject leftPoint;
	public GameObject rightPoint;
	private int direction;
    private bool left;
    private float speed = 0.2f;

	// Use this for initialization
	void Start () 
	{
		direction = Random.Range (0, 10);

        if (direction <= 5)
        {
            left = true;
        } else
        { 
            left = false;
        }
    }

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.name == "RightPoint" || other.name == "LeftPoint")
            left = !left;
        direction = Random.Range(0, 1);
        
	}

	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.L))
            left = !left;
        if (left)
        {
            gameObject.transform.Translate(Vector3.left * speed);
        }

        if (!left)
        {
            gameObject.transform.Translate(-Vector3.left * speed);
        }
    }
}
  
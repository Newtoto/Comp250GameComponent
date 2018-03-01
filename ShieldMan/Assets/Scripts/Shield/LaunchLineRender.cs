using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLineRender : MonoBehaviour {

	LineRenderer line;

	public float velocity;
	public float angle;
	public int resolution = 15;

	public GameObject PlayerPositionRef;

	private float gravity;
	private float radianAngle;
	private float maxDistance;

	// Use this for initialization
	void Awake () 
	{
		line = GetComponent<LineRenderer> ();
		gravity = Mathf.Abs (Physics2D.gravity.y);
	}

	void Update()
	{
		RenderArc ();
	}


	void RenderArc ()
	{
		line.positionCount = resolution + 1;
		line.SetPositions(CalculateArchArray());

	}

	Vector3[] CalculateArchArray()
	{
		Vector3[] arcArray = new Vector3[resolution + 1];
		radianAngle = Mathf.Deg2Rad * angle;
		maxDistance = (velocity * velocity * Mathf.Sin (2 * radianAngle)) / gravity;

		for (int i = 0; i <= resolution; i++)
		{
			float t = (float)i / (float)resolution;
			arcArray [i] = CalculateArchPoint (t, maxDistance);
		}

		print ("Worked");
		return arcArray;
	}

	Vector3 CalculateArchPoint(float t, float maxDistance)
	{
		float x = t * maxDistance;
		float y = x * Mathf.Tan (radianAngle) - ((gravity * x * x) / (2 * velocity * velocity * Mathf.Cos (radianAngle) * Mathf.Cos (radianAngle)));
		float z = -1;
		x += PlayerPositionRef.transform.position.x;
		y += PlayerPositionRef.transform.position.y;
		return new Vector3 (x,y,z);
	}

}

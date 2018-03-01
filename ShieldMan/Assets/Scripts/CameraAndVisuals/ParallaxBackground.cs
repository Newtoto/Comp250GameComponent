using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	public float backgroundSize;
	public Transform playerPosition;
	public float parallaxSpeed;

	private Transform[] layers;
	private float viewZone = -20;
	private int leftIndex;
	private int rightIndex;
	private float lastPlayerPosition;

	// Use this for initialization
	private void Start () 
	{
		playerPosition = GameObject.Find("SirShieldMan 1").transform;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
		{
			layers[i] = transform.GetChild(i);
		}
		leftIndex = 0;
		rightIndex = layers.Length - 1;

		parallaxSpeed *= -1;


	}
	
	// Update is called once per frame
	private void Update () 
	{
		float deltaX = playerPosition.position.x - lastPlayerPosition;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);
		lastPlayerPosition = playerPosition.position.x;

		if (playerPosition.position.x < (layers [leftIndex].transform.position.x + viewZone))
		{
			ParallaxLeft ();
		}

		if (playerPosition.position.x > (layers [rightIndex].transform.position.x - viewZone))
		{
			ParallaxRight ();
		}


	}

	private void ParallaxLeft()
	{
		//int lastRight = rightIndex;
		layers [rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
		{
			rightIndex = layers.Length - 1;
		}


	}

	private void ParallaxRight()
	{
		//int lastLeft = leftIndex;
		layers [leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroundSize);
		leftIndex = rightIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
		{
			leftIndex = 0;
		}
	}

}

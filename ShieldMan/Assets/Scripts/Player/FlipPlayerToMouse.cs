using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayerToMouse : MonoBehaviour {


	private Vector3 mousePosition;
	private Vector3 flippedScale;
	private bool facingRight;

	public bool getfacingdirection()
	{
		return facingRight;
	}

	void MouseCheck ()
	{
		mousePosition = Input.mousePosition;
		if (mousePosition.x < Screen.width / 2 && facingRight)
		{
			facingRight = false;
			flippedScale = gameObject.transform.localScale;
			flippedScale.x *= -1;
			gameObject.transform.localScale = flippedScale;
			return;
		} else if (mousePosition.x > Screen.width / 2 && !facingRight)
		{
			facingRight = true;
			flippedScale = gameObject.transform.localScale;
			flippedScale.x *= -1;
			gameObject.transform.localScale = flippedScale;
			return;
		} else
		{
			return;
		}
	}

	void Start()
	{
		mousePosition = Input.mousePosition;
		flippedScale = gameObject.transform.localScale;
		if (mousePosition.x < Screen.width / 2)
		{
			// Facing left
			facingRight = false;
			flippedScale.x = -1;
			transform.localScale = flippedScale;
		} else if (mousePosition.x > Screen.width / 2)
		{
			// Facing right
			facingRight = true;
			flippedScale.x = 1;
			transform.localScale = flippedScale;
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		MouseCheck ();
	}
}

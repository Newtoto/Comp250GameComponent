using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float movementSpeed = 4.0f;
    private float horizontalMovement;	

	public float slowFactor = 2;
	private bool playerSlowed;

	public void setSlowed(bool condition)
	{
		playerSlowed = condition;
	}

	void Update () {
		
        // Get horizontal movement amount
		horizontalMovement  = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;

		if (playerSlowed == true)
		{
			horizontalMovement = horizontalMovement / slowFactor;
		}


        // Create vector 3 using horizontal movement amount
		Vector3 UpdatePositionVector = new Vector3 (horizontalMovement, 0, 0);

        // Get the rigidbody and move position using the vector made from the WASD
        gameObject.GetComponent<Rigidbody2D> ().transform.Translate(UpdatePositionVector);

		}
	}
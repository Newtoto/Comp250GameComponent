using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGlide : MonoBehaviour {

	private Vector3 mousePosition;
	public float glideThreshold = 0.6f;
	public float glidePower = 0.2f;
    private float verticalPlayerVelocity;
    public Vector2 mousePos;

	public GameObject ShieldManRef;

    public bool canGlide;

    // Used by other scripts to check if player is gliding
    public bool isGliding;


	void glideDetection () 
	{

        // Get vertical velocity of the player
		verticalPlayerVelocity = ShieldManRef.GetComponent<Rigidbody2D>().velocity.y;

		if (gameObject.transform.localRotation.z >= glideThreshold && verticalPlayerVelocity < 0 && canGlide)
		{
            // Give player drag if gliding and falling down
			ShieldManRef.GetComponent<Rigidbody2D> ().gravityScale = glidePower;
            isGliding = true;

        } 
		else
		{
            if(canGlide)
            {
                // Set default gravity to 1
				ShieldManRef.GetComponent<Rigidbody2D>().gravityScale = 1;

				if (gameObject.transform.localRotation.z >= glideThreshold)
                {
                    isGliding = true;
                }
                else
                {
                    isGliding = false;
                }
            }
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		glideDetection ();
	}
}

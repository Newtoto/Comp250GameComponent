using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanUpdraft : MonoBehaviour {

	public float upwardDraft;

    // Add force to all rigidbodies in trigger zone
	void OnTriggerStay2D(Collider2D col) 
	{
        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();

        // Check if the object is player
        if (col.gameObject.tag == "Player")
        {
            // Only add force to player if gliding
			if (col.gameObject.GetComponentInChildren<ShieldGlide>().isGliding)
            {
                rb.AddForce(new Vector2(0.0f, upwardDraft), ForceMode2D.Impulse);
            }
            
        }
        else
        {
            // Add force to all other gameObjects if they have a rigidBody
            if (rb)
            {
                rb.AddForce(new Vector2(0.0f, upwardDraft), ForceMode2D.Impulse);
            }
        }
	}
}

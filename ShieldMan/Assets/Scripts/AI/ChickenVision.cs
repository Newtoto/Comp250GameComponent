using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenVision : MonoBehaviour {

    // Controlled by chicken controller
    public bool facingLeft;

    // How far the chicken can see
    public float visionDistance;

    // Direction of chicken's line of sight
    private Vector2 direction;


    // What the chicken sees, accessed by chicken controller script
    public bool canSeeSomething = false;
    public GameObject seenObject;


    // -- DEFAULT UNITY UPDATE FUNCTION --
	void Update () {

        // Direction of chicken's vision
        if (!facingLeft)
        {
            // Raycast right
            direction = new Vector2(1, 0);
        }
        else
        {
            // Raycast left
            direction = new Vector2(-1, 0);
        }

        // Find what the first thing in the chicken's vision is
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionDistance);

        if (hit)
        {
            // Tell the controller that the chicken can see something
            canSeeSomething = true;

            // Get the object that has been hit
            GameObject hitObject = hit.collider.gameObject;

            // Draw the chicken's vision
            Debug.DrawLine(transform.position, hit.point);

            // Assign values to seen object
            seenObject = hitObject;
        }
        else
        {
            // Tell the controller that the chicken can't see something
            canSeeSomething = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenRunAbout : MonoBehaviour {

    // -- VARIABLE INITIALISATION --
    // Controlled by chicken controller
    public bool facingLeft;
    public float movementSpeed;

    // Rigidbody of the chicken
    private Rigidbody2D chickenRb;

    // -- DEFAULT UNITY START AND UPDATE FUNCTIONS --
    void Start () {
        // Get rigidbody of chicken
        chickenRb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        // Move chicken rigidbody
        if (!facingLeft)
        {
            // Go right
            chickenRb.transform.Translate(new Vector2(movementSpeed, 0));
        }
        else
        {
            // Go left
            chickenRb.transform.Translate(new Vector2(-movementSpeed, 0));
        }
    }
}

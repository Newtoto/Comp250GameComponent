using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenJump : MonoBehaviour {

    // How often the chicken jumps, set by controller
    public float jumpRate;
    // How high the chicken can jump, set by controller
    public float jumpPower;
    // How high the chicken jumps whilst in the air
    public float secondaryJumpPower;


    // Calculated force of the jump
    private Vector2 jumpForce;
    private Rigidbody2D chickenRb;

    private bool jumping;

    IEnumerator Jump()
    {
        // Calculate force added by the jump
        jumpForce = new Vector2(0, jumpPower);

        // Add upward force for duration
        // Primary jump
        jumping = true;
        yield return new WaitForSeconds(0.1f);
        jumping = false;
        yield return new WaitForSeconds(0.2f);

        // Calculate force added by the jump
        jumpForce = new Vector2(0, secondaryJumpPower);
        // Secondary jump
        jumping = true;
        yield return new WaitForSeconds(0.1f);
        jumping = false;

        // Jump cooldown
        yield return new WaitForSeconds(jumpRate);
        
        // Jump again
        StartCoroutine(Jump());
    }

	// Use this for initialization
	void Start () {
        // Get the rigidbody of the chicken once
        chickenRb = GetComponent<Rigidbody2D>();

        // Start jumping
        StartCoroutine(Jump());
    }

    void Update()
    {
        // Calculate force added by the jump
        jumpForce = new Vector2(0, jumpPower);

        // Add upward force for jump duration
        if (jumping)
        {
            chickenRb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBash : MonoBehaviour
{
    // Adjustable value for bash force
    public float pushBack;

    // Checks if there is something to bash off of
    private bool canBash;

    // Used to add force to player
    public GameObject player;
    private Rigidbody2D playerRigidbody;

    // Contains check for whether the player can bash
    public GameObject bashCollider;
    public GameObject shieldSprite;

    // Used to know where the force is being applied to the player 
    public Vector2 shieldPointingDirection;

    // Used to move the shield
    public float reloadTime;
    private Vector3 shieldDefaultPosition;
    private Vector3 bashMovement;
    private bool isBashing;
    public bool dontAllowArmMovement;

    public AudioClip clip;
    public AudioSource audioSource;

    void ApplyForceToPlayer()
    {
        audioSource.PlayOneShot(clip);

        // Get mouse position relative to player and normalize
        Vector2 Pos = Camera.main.WorldToScreenPoint(transform.position);
        shieldPointingDirection.x = Input.mousePosition.x - Pos.x;
        shieldPointingDirection.y = Input.mousePosition.y - Pos.y;
        shieldPointingDirection.Normalize();

        StartCoroutine("ReloadBash");

        // Apply bash force to player
        if (canBash)
        {
            playerRigidbody.AddForceAtPosition(-shieldPointingDirection * pushBack, shieldPointingDirection);
        }
    }

    public IEnumerator ReloadBash()
    {
        // Set aim direction for shield movement
        bashMovement.x = shieldPointingDirection.x;
        bashMovement.y = shieldPointingDirection.y;

        // Move shield away from player
        shieldSprite.transform.position += bashMovement;

        // Pause before bringing the shield back in
        yield return new WaitForSeconds(reloadTime);
        shieldSprite.transform.localPosition = shieldDefaultPosition;

        // Let player bash again
        isBashing = false;
    }

    void Start()
    {
        // Set default position for shield to return to
        shieldDefaultPosition = shieldSprite.transform.localPosition;

        // Initialise as new vector 3 to overwrite values in shield movement
        bashMovement = new Vector3(0.0f, 0.0f, 0.0f);

        playerRigidbody = player.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if player can bash off something
        canBash = bashCollider.GetComponent<BashCheck>().canBash;

        // Bash
        if (Input.GetMouseButtonDown(1) && !isBashing && !dontAllowArmMovement)
        {
            isBashing = true;
            ApplyForceToPlayer();
        }
    }

}


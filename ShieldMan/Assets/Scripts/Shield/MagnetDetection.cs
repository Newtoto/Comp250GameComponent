using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetDetection : MonoBehaviour {

    // How fast the magnet pulls in the player
    public float magnetStrength;
    public float maxMagnetPull;

    // Magnet strength adjusted for distance
    private float relativeMagnetStrength;
    private float distanceFromMagnet;

    // Magnets change this value when they detect the player is near
    public bool isInMagnetRange;

    // Used to move player and reduce gravity for smoothness
    private GameObject player;
    private Rigidbody2D playerRb;

    // Checks if bashing disables magnet
    private bool isOnMagnet;

    // Stops checking for magnet when weakened
    private bool isMagnetWeakened;

    // How long the magnet disables for after being bashed
    public float weakMagnetDuration;

    private void Start()
    {
        // Get player and its rigidbody once
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void MoveToMagnet(Vector2 targetPoint)
    {
        // Disable gliding when moving towards magnet
        player.GetComponentInChildren<ShieldGlide>().canGlide = false;

        distanceFromMagnet = Vector2.Distance(targetPoint, transform.position);
        if (distanceFromMagnet > 2)
        {
            isOnMagnet = false;
            // Calculate relative magnet strength using distance from magnet
            Debug.Log(distanceFromMagnet);
            relativeMagnetStrength = magnetStrength / distanceFromMagnet;

            // Cap relative magnet strength to set amount
            if(relativeMagnetStrength > maxMagnetPull)
            {
                relativeMagnetStrength = maxMagnetPull;
            }

            float step = relativeMagnetStrength * Time.deltaTime;
            playerRb.transform.position = Vector2.MoveTowards(player.transform.position, targetPoint, step);
        }
        else
        {
            if (!isOnMagnet)
            {
                isOnMagnet = true;
            }
        }
    }

    void CheckForMagnet()
    {
        // Get middle of shield to start raycast from
        Vector2 raycastStart = new Vector2(transform.position.x, transform.position.y);

        // Get the position of the mouse
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Raycast from the middle of the shield in the direction of the mouse
        RaycastHit2D hit = Physics2D.Raycast(raycastStart, (worldPoint - raycastStart).normalized);

        // Check to see if shield is pointing towards the magnet
        if (hit.collider.gameObject.tag == "Magnet")
        {
            // Disable gliding when moving towards magnet
            player.GetComponentInChildren<ShieldGlide>().canGlide = false;

            // Descrease gravity if the player is below the magnet for smooth movement
            if (player.transform.position.y < hit.collider.gameObject.transform.position.y)
            {
                playerRb.gravityScale = 0;
            }
            else
            {
                playerRb.gravityScale = 1;
            }

            // Start moving player towards magnet
            MoveToMagnet(hit.collider.gameObject.transform.position);
        }
        else
        {
            // Reset gravity
            playerRb.gravityScale = 1;

            // Enable gliding
            player.GetComponentInChildren<ShieldGlide>().canGlide = true;
        }
        Debug.DrawLine(raycastStart, hit.point);
    }

    public IEnumerator WeakenMagnetTemp()
    {
        // Reset gravity
        playerRb.gravityScale = 1;

        // Bool used to stop pulling player
        isMagnetWeakened = true;

        // Wait before returning magnet strength to normal
        yield return new WaitForSeconds(weakMagnetDuration);

        // Re-enable magnet
        isMagnetWeakened = false;
    }

    void Update()
    {
        if (isInMagnetRange)
        {
            if (Input.GetMouseButtonDown(1) && isOnMagnet == true)
            {
                // Disable magnet for a duration
                StartCoroutine("WeakenMagnetTemp");
            }

            //Only check for magnet if it's not weakened
            if (!isMagnetWeakened)
            {
                //Check to see if shield is pointing towards magnet
                CheckForMagnet();
            }
        }
        else
        {
            // Reset gravity if out of magnet range
            playerRb.gravityScale = 1;
        }
    }
}

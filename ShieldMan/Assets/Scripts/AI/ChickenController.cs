using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour {

    // -- VARIABLE INITIALISATION --

    // -- Editable variables
    //__ChickenController__
    // How long the chicken is scared for
    public float scareDuration;
    // __ChickenRunAbout__
    // How fast the chicken moves
    public float movementSpeed;
    // How fast the chicken moves when scared
    public float scaredMovementSpeed;
    // __ChickenVision__
    // How far the chicken can see
    public float visionDistance;
    // __ChickenJump__
    // How often the chicken jumps
    public float jumpRate;
    // How high the chicken can jump
    public float jumpPower;
    // How high the chicken jumps whilst in the air
    public float secondaryJumpPower;

    // Controlls type of behaviour (will only be used when multiple types are available)
    public string chickenType;

    // 1 is right, -1 is left
    private bool facingLeft;

    // Chicken emotions effect how it acts
    // Gets scared when player is near, increases speed and jumps
    private bool scared = false;

    // Initialise scripts
    private ChickenRunAbout runAbout;
    private ChickenVision vision;
    private ChickenJump jump;

    // What the chicken last saw, used to check for new objects
    private GameObject previouslySeenObject;

    // Changes whether the chicken will turn around when it hits something
    private bool willTurnAroundOnNextCollision = true;


    // -- CUSTOM FUNCTIONS --
    // Randomly chooses which direction the chicken will face
    void ChooseFacedDirection()
    {
        int randomInt = Random.Range(0, 2);
        if (randomInt == 0)
        {
            // Start off facing right
            facingLeft = false;
        }
        else
        {
            // Start off facing left if randomInt is 1
            facingLeft = true;
        }

        UpdateFacedDirectionOfChildScripts(facingLeft);
    }

    // Updates the scripts that use facedDirection with new value
    void UpdateFacedDirectionOfChildScripts(bool newFacingLeft)
    {
        // Update controller's bool
        facingLeft = newFacingLeft;

        // Update bools of affected scripts
        runAbout.facingLeft = facingLeft;
        vision.facingLeft = facingLeft;
    }

    // Reverse the direction the chicken is facing
    void ReverseFacedDirection()
    {
        facingLeft = !facingLeft;
        GetComponent<SpriteRenderer>().flipX = facingLeft;
        UpdateFacedDirectionOfChildScripts(facingLeft);
    }

    // Figure out what to do about a seen object
    void ReactToObject(GameObject otherObject)
    {
        Debug.Log(otherObject.tag);
        // Check if the object is recognised by its tag
        if(otherObject.tag == "Climbable")
        {
            // Do climbing action
            // TODO, calculate target height using collider2D
            float calculatedTargetHeight = 1.0f;

            StartCoroutine(AttemptClimb(1.0f));
        }
        else
        {
            // Prepare to turn around when it hits
            willTurnAroundOnNextCollision = true;
        }

        // Calculate the distance to the seen object
        float distanceToObject = Mathf.Abs(gameObject.transform.position.x - otherObject.transform.position.x);

        // Approximation of how long it will take to reach the object
        float timeToObject = (distanceToObject - transform.localScale.x) / movementSpeed * Time.deltaTime;
    }

    // Turns around if chicken is close enough to an object
    void TurnAroundOnCollision(GameObject otherObject)
    {
        // Calculate the distance to the seen object
        float distanceToObject = Mathf.Abs(gameObject.transform.position.x - otherObject.transform.position.x);

        // Approximate distance to the outside of the collider
        float touchingDistance = 3.5f;

        // Turn around when close
        if (distanceToObject < touchingDistance)
        {
            ReverseFacedDirection(); 
        }
    }

    // Attempt to climb up an object for a duration
    IEnumerator AttemptClimb(float otherObjectHeight)
    {
        // How long the chicken will try to climb up a single object for
        float attemptTime = 5.0f;
        bool climbSuccessful;

        if(transform.position.y > otherObjectHeight)
        {
            // Jump up one more time and start moving again

            climbSuccessful = true;
            
            // Break out of coroutine
            yield return null;
        }
        else
        {
            // Keep jumping
        }

        yield return new WaitForSeconds(attemptTime);

        ReverseFacedDirection();
    }

    // Stay scared for set duration
    IEnumerator Scared(float scareDuration)
    {
        scared = true;

        yield return new WaitForSeconds(scareDuration);

        scared = false;
    }


    // -- DEFAULT UNITY FUNCTIONS --

    // Use this for initialization
    void Start () {
        // -- Creating scripts --
        // Create ChickenRunAbout script and transfer customisable variables
        runAbout = gameObject.AddComponent<ChickenRunAbout>();
        runAbout.movementSpeed = movementSpeed;

        // Create ChickenVision script and transfer customisable variables
        vision = gameObject.AddComponent<ChickenVision>();
        vision.visionDistance = visionDistance;

        // Create ChickenJump script and transfer customisable variables
        jump = gameObject.AddComponent<ChickenJump>();
        jump.jumpRate = jumpRate;
        jump.jumpPower = jumpPower;
        jump.secondaryJumpPower = secondaryJumpPower;
        jump.enabled = false;

        // Randomly choose if the chicken will face left or right
        ChooseFacedDirection();
    }
	
	// Update is called once per frame
	void Update () {

        // Chicken is in visible range of an object
        if (vision.canSeeSomething)
        {
            // React to the player
            if(vision.seenObject.tag == "Player")
            {
                // Turn around
                ReverseFacedDirection();
                // Get scared
                StartCoroutine(Scared(scareDuration));
            }

            // Check if the object has already been reacted to
            if (vision.seenObject != previouslySeenObject)
            {
                // Default willTurnAroundOnNextCollision to false
                willTurnAroundOnNextCollision = false;

                // Set previously seen object to this seen object
                previouslySeenObject = vision.seenObject;

                // First time reaction to the object
                ReactToObject(vision.seenObject);
            }
            else
            {
                // Object has already had initial reaction
                if (willTurnAroundOnNextCollision)
                {
                    // Calculate distance to object and turn around when hit
                    TurnAroundOnCollision(vision.seenObject);
                }
            }
        }

        // What to do when the chicken is scared
        if (scared)
        {
            // Start jumping and increase movement speed
            jump.enabled = true;
            runAbout.movementSpeed = scaredMovementSpeed;
        }
        else
        {
            // Stop jumping and revert movement speed to default
            jump.enabled = false;
            runAbout.movementSpeed = movementSpeed;
        }

        // Changes the direction of the chicken manually, used for debugging
        if (Input.GetKeyDown(KeyCode.T))
        {
            ReverseFacedDirection();
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour {

    public GameObject shieldMan;
    [CustomEditorHeaders("Magnet Variables", 15, 255,0,0,0.5f)]
    public float magnetStrength;

    public float waitForSeconds = 1f;
    private bool canFall = true;

    private float moveSpeedOrig;
    private bool moveMe = false;

	// Use this for initialization
	void Start () {
        StartCoroutine("CheckForShield");
        moveSpeedOrig = shieldMan.GetComponent<Movement>().movementSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckForShield();
        if (Input.GetMouseButton(1) && canFall == true)
        {
            shieldMan.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            canFall = true;
            Debug.Log("Bashing Shit Up");
            shieldMan.GetComponent<Movement>().movementSpeed = moveSpeedOrig;
        }

        //if (shieldMan.transform.position != new Vector3(transform.position.x, transform.position.y + 5) && moveMe == true)
        //{
        //    shieldMan.transform.position = new Vector3(Mathf.Lerp(shieldMan.transform.position.x, transform.position.x -1 , Time.deltaTime * 5), Mathf.Lerp(shieldMan.transform.position.y, transform.position.y + 5, Time.deltaTime * 5));
        //}
        //else
        //{
        //    moveMe = false;
        //}
    }

    void CheckForShield ( )
    {
        Debug.Log("Checking for shield");
        if (Vector2.Distance(transform.position, shieldMan.transform.position) < magnetStrength && canFall == true)
        {
            canFall = false;
            Debug.Log("Grabbing the shield");
            shieldMan.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //moveMe = true;
            shieldMan.GetComponent<Movement>().movementSpeed = 0;
            shieldMan.transform.position = new Vector3(transform.position.x, transform.position.y + 5);

        }
    }
}

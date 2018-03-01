using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMagnet : MonoBehaviour {

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
        moveSpeedOrig = shieldMan.GetComponentInParent<Movement>().movementSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //StartCoroutine("CheckForShield");

    }

    IEnumerator CheckForShield ( )
    {
        Debug.Log("Checking for shield Rope Style");
        if (Vector2.Distance(transform.position, shieldMan.transform.position) < magnetStrength)
        {
            Debug.Log("Grabbing the shield for the rope");
            //shieldMan.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            shieldMan.GetComponentInParent<Movement>().movementSpeed = 0;
            shieldMan.transform.position = new Vector3(transform.position.x, transform.position.y);
            shieldMan.transform.rotation = new Quaternion(0, 0, 75f, 0);
            yield return new WaitForSeconds(0.5f);
            //shieldMan.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            shieldMan.GetComponentInParent<Movement>().movementSpeed = moveSpeedOrig;
            yield return new WaitForSeconds(5f);
            StartCoroutine("CheckForShield");
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine("CheckForShield");
        }
    }
}

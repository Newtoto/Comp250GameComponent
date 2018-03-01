using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShield : MonoBehaviour {

	public GameObject parentCharacter;
	private float angle;

	public bool mouseInputFlip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 Pos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - Pos;

		mouseInputFlip = parentCharacter.GetComponent<FlipPlayerToMouse> ().getfacingdirection ();
		if (mouseInputFlip == false)
		{
			angle = Mathf.Atan2 (-dir.y, -dir.x) * Mathf.Rad2Deg;
		} else
		{
			angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		}
			
		transform.rotation = Quaternion.AngleAxis (angle, (Vector3.forward));

	}

}

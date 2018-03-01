using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayerSpeed : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D (Collider2D Coll) 
	{
		if (Coll.gameObject.tag == ("Player"))
		{
			Coll.gameObject.GetComponent<Movement> ().setSlowed (true);

		}

	}

	void OnTriggerExit2D (Collider2D Coll) 
	{
		if (Coll.gameObject.tag == ("Player"))
		{
			Coll.gameObject.GetComponent<Movement> ().setSlowed (false);
		}

	}
}

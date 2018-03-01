using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoulder : MonoBehaviour {

    public float lifetime;

	// Destroy self after set time
	void Start () {
        Destroy(gameObject, lifetime);
    }

}

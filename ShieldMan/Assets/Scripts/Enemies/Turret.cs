using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour 
{
	//Settings for designers to adjust.
	[Header("Projectile Settings")]
	public GameObject projectilePrefab;
	public float timeBetweenShots;

	void OnTriggerEnter2D(Collider2D Coll)
	{
		if (Coll.gameObject.tag == ("Player"))
		{
			StartCoroutine ("Shoot");
		}
	}

	void OnTriggerExit2D(Collider2D Coll)
    {
		if (Coll.gameObject.tag == ("Player"))
		{
			StopCoroutine ("Shoot");
		}
    }

    //Function for shooting
    IEnumerator Shoot()
	{
		Instantiate (projectilePrefab, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(timeBetweenShots);
		StartCoroutine("Shoot");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOnCol : MonoBehaviour {

    Coroutine rotuine;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>().constraints;
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(rotuine == null)
            rotuine = StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.6f);

        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        rotuine = null;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}

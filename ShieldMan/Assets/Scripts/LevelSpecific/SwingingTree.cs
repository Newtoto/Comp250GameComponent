using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingTree : MonoBehaviour {

    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Sup");
            rb.freezeRotation = false;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour {

    private GameObject player, shield;
    public List<GameObject> ends;
    public bool onZip;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shield = GameObject.Find("ShieldieShield");
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Vector2.Distance(ends[0].transform.position, player.transform.position) <= 3 && !onZip)
        {            
            Debug.Log("Riding the waves");
            player.transform.position = ends[0].transform.position;
            shield.GetComponent<Transform>().localRotation = transform.localRotation;
            Cursor.lockState = CursorLockMode.Locked;
            onZip = true;
        } 
        if (onZip)
        {
            Debug.Log("Enabling Shield");
            //player.GetComponent<Rigidbody2D>().velocity = new Vector2(50,-3);
            shield.GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<BoxCollider2D>().usedByEffector = false;
        } 
        if (Vector2.Distance(ends[1].transform.position, player.transform.position) <= 2 && onZip)
        {
            Debug.LogWarning("Get off my rope");
            shield.GetComponent<BoxCollider2D>().enabled = false; 
            Cursor.lockState = CursorLockMode.None;
            onZip = false;
            //player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.position = ends[0].transform.position;
            shield.GetComponent<Transform>().localRotation = transform.localRotation;
        }
    }

}

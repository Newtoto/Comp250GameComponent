using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Shield")
        {
            Debug.Log("Go Fuck Yourself Andy");

            collision.transform.eulerAngles = new Vector3(0, 0, 55.59f);
        }
    }
}

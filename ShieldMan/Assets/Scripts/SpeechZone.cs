using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechZone : MonoBehaviour
{
    public GameObject whatToEnableOnCol;

	void Start ()
    {

    }
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "SirShieldMan")
        {
            whatToEnableOnCol.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "SirShieldMan")
        {
            whatToEnableOnCol.SetActive(false);
        }
    }
}

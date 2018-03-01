using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetShieldDetection : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Tell player they are in range of this magnet
            collision.GetComponentInChildren<MagnetDetection>().isInMagnetRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Tell player they are out of range of this magnet
            collision.GetComponentInChildren<MagnetDetection>().isInMagnetRange = false;
        }
    }


}

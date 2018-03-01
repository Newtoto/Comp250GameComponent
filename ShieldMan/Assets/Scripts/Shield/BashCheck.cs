using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashCheck : MonoBehaviour {

    public bool canBash;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Only enable bash for non-trigger colliders
        if(!collision.isTrigger)
        {
            // If there is something in the shield bash zone, make canBash true
            canBash = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // If there is something in the shield bash zone, make canBash true
        canBash = false;
    }
}

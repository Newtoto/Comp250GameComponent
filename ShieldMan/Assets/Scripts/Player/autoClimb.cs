using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoClimb : MonoBehaviour {

    public List<GameObject> corners;
    private float corner1, corner2;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (corners.Count == 2)
            {
                corner1 = Vector2.Distance(col.transform.position, corners[0].transform.position);
                corner2 = Vector2.Distance(col.transform.position, corners[1].transform.position);
                if (corner1 < corner2)
                {
                    col.transform.position = new Vector2(corners[0].transform.position.x, corners[0].transform.position.y);
                    col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            else
            {
                col.transform.position = new Vector2(corners[1].transform.position.x, corners[1].transform.position.y);
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            }
            else
            {
                col.transform.position = new Vector2(corners[0].transform.position.x, corners[0].transform.position.y); 
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }

}

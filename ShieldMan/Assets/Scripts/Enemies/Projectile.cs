using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour 
{
	private GameObject player;
	private Rigidbody2D rb;
    private Vector3 target;
    public float speed = 5f;
    public bool homing;

    void HitTarget()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        if (collision.gameObject.tag == "Player")
        {
            HitTarget();
        }
        Destroy(gameObject);
    }

    void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
        target = player.GetComponent<Transform>().position;
        StartCoroutine(Destroy());
	}
		
    void Update () 
	{
        transform.Rotate(Vector3.forward * Time.deltaTime * 200);
        if (homing)
        {
            target = player.GetComponent<Transform>().position;
        }
        Vector3 targetDirection = target - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		transform.Translate (targetDirection.normalized * distanceThisFrame, Space.World);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}

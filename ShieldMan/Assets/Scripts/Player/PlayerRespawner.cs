using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawner : MonoBehaviour {

    private SpriteRenderer [] shieldmanSprites;

    // Get all player sprites to disable on death
    private void Start()
    {
        shieldmanSprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }

    public void KillPlayer(GameObject particleEffect)
    {
        // Disable shieldman sprites
        for (var i = 0; i < shieldmanSprites.Length; i++)
        {
            shieldmanSprites[i].enabled = false;
        }

        // Instantiate chosen particle effect
        Instantiate(particleEffect, gameObject.transform.position, Quaternion.identity);

        // Wait, then load the scene
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        // Stops blood from colliding with objects
        GetComponent<Collider2D>().enabled = false;

        // Wait to let splatter play
        yield return new WaitForSeconds(0.4f);

        // Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}

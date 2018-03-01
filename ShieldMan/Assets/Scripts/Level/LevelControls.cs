using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControls : MonoBehaviour {

    private GameObject player;
    public GameObject suicideParticles;

	// Use this for initialization
	void Start () {

        // Get the player, return error message if not found
        player = GameObject.Find("SirShieldMan");
        if(!player)
        {
            Debug.Log("Player no found, has SirShieldMan been renamed?");
        }

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.GetAxis("Suicide"));
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("It's killin time");
            player.GetComponent<PlayerRespawner>().KillPlayer(suicideParticles);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetLevelTimer : MonoBehaviour {

	private GameObject timer;
	private float tempTime;

	// Use this for initialization
	void Awake () 
	{
		timer = GameObject.Find ("Timer");
	}
	
	// Update is called once per frame
	void Update () 
	{
		tempTime = timer.GetComponent<LevelTimer> ().time;

		var minutes = Mathf.FloorToInt(tempTime / 60);

		var seconds = (tempTime % 60);

		var miliseconds = Mathf.FloorToInt (tempTime * 1000) % 1000;

		gameObject.GetComponent<Text>().text = "Your Time: " + string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	public Text countdownLabel;

	public float time;

	void Update () 
	{
		time += Time.deltaTime;

		var seconds = Mathf.FloorToInt (time % 60);

		var minutes = Mathf.FloorToInt (time / 60);

		var miliseconds = Mathf.FloorToInt (time * 1000) % 1000; 


		countdownLabel.text = string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, miliseconds);
	}
}
